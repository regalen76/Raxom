using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    float currentHealth;
    public HealthBar healthBar;
    public bool isDead = false;
    public bool secondPhase = false;

    public float nextAttackTime = 0f;

    public static Enemy instance;

    Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        if (this.gameObject.name == "TrashMonster")
        {
            currentHealth = 500;
            healthBar.SetMaxHealth(500);
        }
        else if (this.gameObject.name == "ToothWalker")
        {
            currentHealth = 300;
            healthBar.SetMaxHealth(300);
        } else if (this.gameObject.name == "SpecialBot" || this.gameObject.name == "SpecialBot(Clone)")
        {
            currentHealth = 75;
            healthBar.SetMaxHealth(75);
        }
        else if (this.gameObject.name == "Boss")
        {
            currentHealth = 400;
            healthBar.SetMaxHealth(400);
        }
        else
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float playerdamage) {
        StartCoroutine(hurt(playerdamage)); //delay 0.3 
    }

    public IEnumerator hurt(float playerdamage) { //delay function
        if (this.gameObject.name == "Boss")
        {
            yield return new WaitForSeconds(0.3f);
            BossWeapon.instance.nextAttackTime = Time.time + 1f / 1.5f;
            currentHealth -= playerdamage; //takedamage
            healthBar.SetHealth(currentHealth);
            animator.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                if (secondPhase == false)
                {
                    Buff();
                } else if (secondPhase == true)
                {
                    Die();
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            AIWeapon.instance.nextAttackTime = Time.time + 1f / 1.5f;
            currentHealth -= playerdamage; //takedamage
            healthBar.SetHealth(currentHealth);
            animator.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Buff()
    {
        animator.SetTrigger("Buff");
        secondPhase = true;
        currentHealth = 300;
        healthBar.SetMaxHealth(300);
    }

    private void Die() {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Level2.instance.killed += 1;
            animator.SetBool("IsDead", true);
        } else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Level3.instance.killed += 1;
            animator.SetTrigger("BossDead");
        }
        else
        {
            Level.instance.killed += 1;
            animator.SetBool("IsDead", true);
        }
        
        isDead = true;
        healthBar.gameObject.SetActive(false); //hilangkan health bar

        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<Collider2D>().enabled = false; //disable collider

        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>(); //disable script
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }

    //sound section
    public void SpecialDroidSound()
    {
        FindObjectOfType<AudioManager2>().Play("SpecialDroidSound");
    }

    public void AttackDroidSound()
    {
        FindObjectOfType<AudioManager2>().Play("AttackDroidSound");
    }

    public void AssassinDroidSound1()
    {
        FindObjectOfType<AudioManager2>().Play("AssassinDroidSound1");
    }

    public void AssassinDroidSound2()
    {
        FindObjectOfType<AudioManager2>().Play("AssassinDroidSound2");
    }

    public void ToothWalkerSound()
    {
        FindObjectOfType<AudioManager2>().Play("ToothWalker");
    }

    public void TrashMonsterSound1()
    {
        FindObjectOfType<AudioManager2>().Play("TrashMonster1");
    }

    public void TrashMonsterSound2()
    {
        FindObjectOfType<AudioManager2>().Play("TrashMonster2");
    }

    public void BossPunchSound()
    {
        FindObjectOfType<AudioManager2>().Play("BossPunch");
    }

    public void BossShoot1Sound()
    {
        FindObjectOfType<AudioManager2>().Play("BossShoot1");
    }

    public void BossShoot2Sound()
    {
        FindObjectOfType<AudioManager2>().Play("BossShoot2");
    }

    public void Buff1()
    {
        FindObjectOfType<AudioManager2>().Play("Buff1");
    }

    public void Buff2()
    {
        FindObjectOfType<AudioManager2>().Play("Buff2");
    }
}
