using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 35;       //melee 1
    
    public Vector3 attackOffset;
    public float attackRange = 2.5f;
    public LayerMask attackMask;

    public float nextAttackTime = 0f;



    public int attackDamage2 = 35;      //melee 2

    public Vector3 attackOffset2;
    public float attackRange2 = 2.5f;
    public LayerMask attackMask2;

    public float nextAttackTime2 = 0f;



    public int attackDamage3 = 35;      //range 1

    public Vector3 attackOffset3;
    public float attackRange3 = 2.5f;
    public LayerMask attackMask3;

    public float nextAttackTime3 = 0f;



    public int attackDamage4 = 35;      //range 2

    public Vector3 attackOffset4;
    public float attackRange4 = 2.5f;
    public LayerMask attackMask4;

    public float nextAttackTime4 = 0f;



    public int attackDamage5 = 50;      //range 3

    public Vector3 attackOffset5;
    public float attackRange5 = 2.5f;
    public LayerMask attackMask5;

    public float nextAttackTime5 = 0f;



    public int attackDamage6 = 50;      //range 4

    public Vector3 attackOffset6;
    public float attackRange6 = 2.5f;
    public LayerMask attackMask6;

    public float nextAttackTime6 = 0f;


    public static BossWeapon instance;

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

    public void Melee1(){
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

    public void Melee2()
    {
        Vector3 pos2 = transform.position;
        pos2 += transform.right * attackOffset2.x;
        pos2 += transform.up * attackOffset2.y;
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos2, attackRange2, attackMask2);
            if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
            {//jika attack1 animation assassin sedang nyala maka player gak bisa terkena damage
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage2);
                nextAttackTime = Time.time + 1f / 1.5f;
            }
        }
    }

    public void Range1()
    {
        Vector3 pos3 = transform.position;
        pos3 += transform.right * attackOffset3.x;
        pos3 += transform.up * attackOffset3.y;
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos3, attackRange3, attackMask3);
            if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
            {//jika attack1 animation assassin sedang nyala maka player gak bisa terkena damage
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage3);
                nextAttackTime = Time.time + 1f / 1.5f;
            }
        }
    }

    public void Range2()
    {
        Vector3 pos4 = transform.position;
        pos4 += transform.right * attackOffset4.x;
        pos4 += transform.up * attackOffset4.y;
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos4, attackRange4, attackMask4);
            if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
            {//jika attack1 animation assassin sedang nyala maka player gak bisa terkena damage
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage4);
                nextAttackTime = Time.time + 1f / 1.5f;
            }
        }
    }

    public void Range3()
    {
        Vector3 pos5 = transform.position;
        pos5 += transform.right * attackOffset5.x;
        pos5 += transform.up * attackOffset5.y;
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos5, attackRange5, attackMask5);
            if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
            {//jika attack1 animation assassin sedang nyala maka player gak bisa terkena damage
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage5);
                nextAttackTime = Time.time + 1f / 1.5f;
            }
        }
    }

    public void Range4()
    {
        Vector3 pos6 = transform.position;
        pos6 += transform.right * attackOffset6.x;
        pos6 += transform.up * attackOffset6.y;
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos6, attackRange6, attackMask6);
            if (colInfo != null && PlayerCombat.instance.isAttackingAnimation == false && Character2DController.instance.isDashingAnimation == false)
            {//jika attack1 animation assassin sedang nyala maka player gak bisa terkena damage
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage6);
                nextAttackTime = Time.time + 1f / 1.5f;
            }
        }
    }

    void OnDrawGizmosSelected()
	{
        //melee 1
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);


        //melee 2
        Vector3 pos2 = transform.position;
        pos2 += transform.right * attackOffset2.x;
        pos2 += transform.up * attackOffset2.y;

        Gizmos.DrawWireSphere(pos2, attackRange2);


        //Range 1
        Vector3 pos3 = transform.position;
        pos3 += transform.right * attackOffset3.x;
        pos3 += transform.up * attackOffset3.y;

        Gizmos.DrawWireSphere(pos3, attackRange3);


        //Range 2
        Vector3 pos4 = transform.position;
        pos4 += transform.right * attackOffset4.x;
        pos4 += transform.up * attackOffset4.y;

        Gizmos.DrawWireSphere(pos4, attackRange4);


        //Range 3
        Vector3 pos5 = transform.position;
        pos5 += transform.right * attackOffset5.x;
        pos5 += transform.up * attackOffset5.y;

        Gizmos.DrawWireSphere(pos5, attackRange5);


        //Range 4
        Vector3 pos6 = transform.position;
        pos6 += transform.right * attackOffset6.x;
        pos6 += transform.up * attackOffset6.y;

        Gizmos.DrawWireSphere(pos6, attackRange6);
    }
}
