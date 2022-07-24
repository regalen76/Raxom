using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    bool inside;
    public GameObject text;          //text untuk activate
    public GameObject textEnemy;    //text enemy diatas
    public GameObject activated1;   //firt activated beam
    public GameObject malam;    //nyalakan malam
    public GameObject platform; //platform saat battle
    public GameObject mark; //yellow mark

    public GameObject firstEnemy;    //trigger trash monster
    BoxCollider2D firstEnemyCol;  //colnya
    Animator anim;  //animnya
    public GameObject enemyHealth;  //canvas healthnya

    public GameObject leftBarrier;   //pembatas kiri

    private void Start()
    {
        firstEnemyCol = firstEnemy.GetComponent<BoxCollider2D>();
        anim = firstEnemy.GetComponent <Animator>();
        firstEnemyCol.enabled = false;
        enemyHealth.SetActive(false);
    }

    private void Update()
    {
        if (inside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager2>().Stop("Level2 Theme");
                FindObjectOfType<AudioManager2>().Play("True Level2 Theme");

                malam.SetActive(true);
                textEnemy.SetActive(true);
                activated1.SetActive(true);
                leftBarrier.SetActive(true);
                platform.SetActive(true);
                
                firstEnemyCol.enabled=true;
                anim.SetTrigger("WakeUp");
                enemyHealth.SetActive(true);

                mark.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        inside = true;
        text.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
        text.SetActive(false);
    }
}
