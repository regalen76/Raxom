using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Run : StateMachineBehaviour
{

    public float speed = 2.5f;
    public float attackRange = 10f;

    public float attackRate = 5f;

    Transform player;
    Rigidbody2D rb;
    AI ai;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
      player = GameObject.FindGameObjectWithTag("Player").transform;
      rb = animator.GetComponent<Rigidbody2D>();
      ai = animator.GetComponent<AI>();
      enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai.LookAtPlayer();
        

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        if(Enemy.instance.gameObject.name == "TrashMonster")
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, (speed + 5f) * Time.fixedDeltaTime);  //jika trash monster speed khusus
            if (ai.Stop == false)
            {
                rb.MovePosition(newPos);
            }
        } else if(Enemy.instance.gameObject.name == "ToothWalker")
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, (speed + 2.5f) * Time.fixedDeltaTime);  //jika trash monster speed khusus
            if (ai.Stop == false)
            {
                rb.MovePosition(newPos);
            }
        }
        else
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            if (ai.Stop == false)
            {
                rb.MovePosition(newPos);
            }
        }

        if(Enemy.instance.gameObject.name == "Boss")
        {

        }
        else
        {
            if (Time.time >= AIWeapon.instance.nextAttackTime)
            {
                if (Enemy.instance.gameObject.name == "AttackBot" || Enemy.instance.gameObject.name == "AttackBot(Clone)")
                {
                    if (Vector2.Distance(player.position, rb.position) <= 9.5 && enemy.isDead == false)
                    {
                        animator.SetTrigger("Attack");
                    }
                }
                else if (Enemy.instance.gameObject.name == "AssassinBot" || Enemy.instance.gameObject.name == "AssassinBot(Clone)" && enemy.isDead == false)
                {
                    if (Vector2.Distance(player.position, rb.position) <= 3.9)
                    {
                        animator.SetTrigger("Attack");
                    }
                }
                else if (Enemy.instance.gameObject.name == "SpecialBot" || Enemy.instance.gameObject.name == "SpecialBot(Clone)" && enemy.isDead == false)
                {
                    if (Vector2.Distance(player.position, rb.position) <= 5.25)
                    {
                        animator.SetTrigger("Attack");
                    }
                }
                else if (Enemy.instance.gameObject.name == "TrashMonster" || Enemy.instance.gameObject.name == "TrashMonster(Clone)" && enemy.isDead == false)
                {
                    if (Vector2.Distance(player.position, rb.position) <= 10)
                    {
                        animator.SetTrigger("Attack");
                    }
                }
                else if (Enemy.instance.gameObject.name == "ToothWalker" || Enemy.instance.gameObject.name == "ToothWalker(Clone)" && enemy.isDead == false)
                {
                    if (Vector2.Distance(player.position, rb.position) <= 9)
                    {
                        animator.SetTrigger("Attack");
                    }
                }
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
