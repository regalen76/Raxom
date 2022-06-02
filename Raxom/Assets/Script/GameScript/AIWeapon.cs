using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    public int attackDamage = 25;
    
    public Vector3 attackOffset;
    public float attackRange = 2.5f;
    public LayerMask attackMask;

    public float nextAttackTime = 0f;

    public static AIWeapon instance;

    private void Awake()
    {
        instance = this; 
    }

    public void Attack(){
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            nextAttackTime = Time.time + 1f / 1.5f;
        }
    }

    void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
