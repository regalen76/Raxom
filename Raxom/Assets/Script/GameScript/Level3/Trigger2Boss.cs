using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2Boss : MonoBehaviour
{
    bool inside;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(inside == true)
        {
            if (Enemy.instance.animator.GetCurrentAnimatorStateInfo(0).IsName("Droid_attack") == false && Enemy.instance.animator.GetCurrentAnimatorStateInfo(0).IsName("range") == false && Enemy.instance.animator.GetCurrentAnimatorStateInfo(0).IsName("melee2 0") == false && Enemy.instance.animator.GetCurrentAnimatorStateInfo(0).IsName("range2 0") == false)
            {
                anim.SetTrigger("Attack");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inside = false;
        }
    }
}
