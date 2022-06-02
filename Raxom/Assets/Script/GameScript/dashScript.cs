using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerCombat.instance.isDashAttacking)
        {
            PlayerCombat.instance.animator.Play("Assassin_dashattack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PlayerCombat.instance.attackPoint2.position, PlayerCombat.instance.attackRange2, PlayerCombat.instance.enemyLayers);

            // damage enemies
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(PlayerCombat.instance.attackDamage2);
            }

            PlayerCombat.instance.isDashAttacking = false;
        }
        
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
