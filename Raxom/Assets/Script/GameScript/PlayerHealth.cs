using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage; //takedamage
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die(){


        animator.SetBool("IsDead", true);//animation dead

        GetComponent<Collider2D>().enabled =false; //disable collider
        this.enabled = false; //disable script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
