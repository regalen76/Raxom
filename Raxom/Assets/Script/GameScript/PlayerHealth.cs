using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    public GameObject GameOver;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GameOver.SetActive(false);
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

        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled =false; //disable collider

        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>(); //disable script
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }

        GameOver.SetActive(true);
    }
}
