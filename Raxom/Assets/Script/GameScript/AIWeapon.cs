using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    public int attackDamage = 35;
    
    public Vector3 attackOffset;
    public float attackRange = 2.5f;
    public Vector2 attackBotAttackRange;
    public LayerMask attackMask;

    public float nextAttackTime = 0f;

    public static AIWeapon instance;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        if(this.gameObject.name == "SpecialBot" || this.gameObject.name == "AttackBot" || this.gameObject.name == "AssassinBot")
        {
            attackDamage = 5;
        }
    }

    public void Attack(){
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
            {//jika attack1 animation assassin sedang nyala maka player gak bisa terkena damage
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1f / 1.5f;
            }
        } 
    }

    void OnDrawGizmosSelected()
	{
		/*if(this.gameObject.name == "AttackBot" || this.gameObject.name == "SpecialBot" || this.gameObject.name == "AttackBot(Clone)" || this.gameObject.name == "SpecialBot(Clone)")
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Gizmos.DrawWireCube(pos, attackBotAttackRange);
        }
        else*/
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Gizmos.DrawWireSphere(pos, attackRange);
        }
	}
}
