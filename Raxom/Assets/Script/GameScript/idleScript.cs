using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleScript : StateMachineBehaviour
{

    private int selectedIndex = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        selectedIndex = PlayerPrefs.GetInt("selectedIndex");
        if (PlayerCombat.instance.isAttacking && selectedIndex == 0)
        { //assassin
            PlayerCombat.instance.animator.Play("Assassin_attack1");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PlayerCombat.instance.attackPoint.position, PlayerCombat.instance.attackRange, PlayerCombat.instance.enemyLayers);

            // damage enemies
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(PlayerCombat.instance.attackDamage);
            }
        }
        else if (PlayerCombat.instance.isAttacking && selectedIndex == 1)
        { //mage
            PlayerCombat.instance.animator.Play("Mage_attack1");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PlayerCombat.instance.mageAttackPoint.position, PlayerCombat.instance.mageAttackRange, PlayerCombat.instance.enemyLayers);

            // damage enemies
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(PlayerCombat.instance.mageAttackDamage);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerCombat.instance.isAttacking = false;
        PlayerCombat.instance.isDashAttacking = false;
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
