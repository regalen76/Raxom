using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform mageAttackPoint;
    float nextAttackTime = 0f;
    public float delay = 2f;
    public float attackRange = 0.5f;
    public float attackRange2 = 0.5f;
    public float mageAttackRange = 0.5f;
    public float attackDamage = 25;
    public float attackDamage2 = 25;
    public float mageAttackDamage = 25;
    public LayerMask enemyLayers;

    public bool isAttacking = false;
    public bool isAttackingAnimation = false;
    public bool isDashAttacking = false;
    public static PlayerCombat instance;

    private int selectedIndex = 0;

    private void Awake() {
        instance = this;
    }

    private void Start()
    {
        selectedIndex = PlayerPrefs.GetInt("selectedIndex");
    }

    void Update()
    {
        Attack();
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") == true)  //untuk tidak bisa kena damage jika attack1 animation assassin lgi di play
        {
            isAttackingAnimation = true;
        } else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") == false)
        {
            isAttackingAnimation = false;
        }
    }

    private void Attack(){
        if (selectedIndex == 0) //delay attack khusus assassin
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.D) && Character2DController.instance.IsGrounded() == true && !isAttacking && Time.time >= Character2DController.instance.nextDashTime && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack2") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi2") != true)
                {
                    isAttacking = true;
                    nextAttackTime = Time.time + delay;
                }
            }
            if (Input.GetKeyDown(KeyCode.D) && Character2DController.instance.IsGrounded() == true && !isAttacking && Time.time <= Character2DController.instance.nextDashTime)
            {
                isDashAttacking = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D) && Character2DController.instance.IsGrounded() == true && !isAttacking && Time.time >= Character2DController.instance.nextDashTime && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack2") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi2") != true)
            {
                isAttacking = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && Character2DController.instance.IsGrounded() == true && !isAttacking && Time.time <= Character2DController.instance.nextDashTime)
            {
                isDashAttacking = true;
            }
        }
    }

    private void OnDrawGizmosSelected() { //untuk melihat radius attack point di editor
        if(attackPoint == null){
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
        Gizmos.DrawWireSphere(mageAttackPoint.position, mageAttackRange);
    }


    //sound section
    public void MageAttack1()
    {
        FindObjectOfType<AudioManager2>().Play("Mage1");
    }

    public void MageAttack2()
    {
        FindObjectOfType<AudioManager2>().Play("Mage2");
    }

    public void MageCast1()
    {
        FindObjectOfType<AudioManager2>().Play("MageCast");
    }

    public void MageCast2()
    {
        FindObjectOfType<AudioManager2>().Play("JumpStart");
    }

    public void AssassinDash()
    {
        FindObjectOfType<AudioManager2>().Play("AssassinDash");
    }

    public void AssassinDashAttack()
    {
        FindObjectOfType<AudioManager2>().Play("AssassinDashAttack");
    }

    public void AssassinAttack1()
    {
        FindObjectOfType<AudioManager2>().Play("Assassin1");
    }

    public void AssassinAttack2()
    {
        FindObjectOfType<AudioManager2>().Play("Assassin2");
    }

    public void AssassinAttack3()
    {
        FindObjectOfType<AudioManager2>().Play("Assassin3");
    }

    public void AssassinAttack4()
    {
        FindObjectOfType<AudioManager2>().Play("Assassin4");
    }
}
