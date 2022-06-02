using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform mageAttackPoint;
    public float attackRange = 0.5f;
    public float attackRange2 = 0.5f;
    public float mageAttackRange = 0.5f;
    public int attackDamage = 25;
    public int attackDamage2 = 25;
    public int mageAttackDamage = 25;
    public LayerMask enemyLayers;

    public bool isAttacking = false;
    public bool isAttackingAnimation = false;
    public bool isDashAttacking = false;
    public static PlayerCombat instance;

    private void Awake() {
        instance = this;
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
        if(Input.GetKeyDown(KeyCode.D) && !isAttacking && Time.time >= Character2DController.instance.nextDashTime && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Assassin_attack1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_attack2") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi1") != true && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Mage_transisi2") != true)
        {
            isAttacking = true;
        }
        else if(Input.GetKeyDown(KeyCode.D) && !isAttacking && Time.time <= Character2DController.instance.nextDashTime)
        {
            isDashAttacking = true;
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
}
