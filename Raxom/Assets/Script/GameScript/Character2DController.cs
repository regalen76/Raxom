using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2DController : MonoBehaviour
{
    private int selectedIndex = 0;

    private float MovementSpeed = 1;  //basic movement
    private float JumpForce = 1;
    public Animator animator;

    public float dashSpeed;         //dash
    public float dashRate = 2f;
    public float nextDashTime = 0f;
    public bool isDashingAnimation = false;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D coll;

    private bool jump;

    [SerializeField] private LayerMask jumpableGround;

    public static Character2DController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        selectedIndex = PlayerPrefs.GetInt("selectedIndex");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded())  //input jump harus update
        {
            jump = true;
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_dash") == true)
        {
            isDashingAnimation = true;
        }
        else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_dash") == false)
        {
            isDashingAnimation = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()   //biar movement gak jitter
    {
        if(selectedIndex == 0)  //jika chara assassin
        {
            MovementSpeed = 15;
            JumpForce = 25;
        } else if(selectedIndex == 1) // jika chara mage
        {
            MovementSpeed = 7;
            JumpForce = 25;
        }
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_dashattack") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack1") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi1") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack2") && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi2"))
        {   //jika melakukan attack1 ass && dashattack ass && mage attack1 && mage attack2 maka gak bisa gerak
            Move();
            Jump();
            Look();
        }

        if(_rigidbody.velocity.y<0.001f){    //ngatur animasi jump
            animator.SetBool("IsJumping",false);
            animator.SetBool("IsFalling",true);
            if(_rigidbody.velocity.y == 0){
                animator.SetBool("IsFalling", false);
            }
            
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_dashattack") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack1") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi1") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack2") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi2"))  //buat player stop ketika nyerang
        {
            this._rigidbody.velocity = Vector3.zero;
        }
    }

    private void Move(){ //Pergerakan basic kiri kanan
        var movement = Input.GetAxis("Horizontal");
        // transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        if(Time.time >= nextDashTime)
        {
            if (Input.GetKey(KeyCode.LeftShift) && IsGrounded()==true && selectedIndex == 0)  //dash kusus assassin
            {
                animator.SetTrigger("Dash");
                StartCoroutine(dashmove(movement,_rigidbody));
                if (GameObject.FindGameObjectWithTag("Player").transform.rotation.y == 0)
                {
                    transform.position += new Vector3(1, 0) * dashSpeed;
                }
                else if (GameObject.FindGameObjectWithTag("Player").transform.rotation.y != 0)
                {
                    transform.position += new Vector3(-1, 0) * dashSpeed;
                }
                nextDashTime = Time.time + 1f / dashRate;
            }
        }
        _rigidbody.velocity = new Vector2(movement * MovementSpeed, _rigidbody.velocity.y); //move biasa
        animator.SetFloat("Speed", Mathf.Abs(movement * MovementSpeed));  //animasi move
    }
    public IEnumerator dashmove(float movement, Rigidbody2D _rigidbody)
    { //delay function
        yield return new WaitForSeconds(0.15f);

        if(GameObject.FindGameObjectWithTag("Player").transform.rotation.y == 0)
        {
            transform.position += new Vector3(1, 0) * dashSpeed;
        }
        else if(GameObject.FindGameObjectWithTag("Player").transform.rotation.y != 0)
        {
            transform.position += new Vector3(-1, 0) * dashSpeed;
        }
        nextDashTime = Time.time + 1f / dashRate;
    }

    private void Look(){
        var movement = Input.GetAxis("Horizontal");
        if(!Mathf.Approximately(0,movement)){
            transform.rotation = movement > 0 ? Quaternion.identity : Quaternion.Euler(0,180, 0);
        }
    }

     private void Jump(){ // Melompat
        if(jump == true){
            jump = false;
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, JumpForce), ForceMode2D.Impulse);

            if(_rigidbody.velocity.y>0.001f){
                animator.SetBool("IsJumping", true);
            }
            
        }
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down, .1f, jumpableGround);
    }
}
