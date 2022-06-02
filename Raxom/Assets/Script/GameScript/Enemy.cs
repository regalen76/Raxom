using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    public float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int playerdamage){
        StartCoroutine(hurt(playerdamage)); //delay 0.3 
    }

    public IEnumerator hurt(int playerdamage){ //delay function
        yield return new WaitForSeconds(0.3f);
        AIWeapon.instance.nextAttackTime = Time.time + 1f / 1.5f;
        currentHealth -= playerdamage; //takedamage
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger ("Hurt");
        if(currentHealth <=0){
            Die();
        }
    }

    private void Die(){

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled =false; //disable collider
        this.enabled = false; //disable script
    }

}
