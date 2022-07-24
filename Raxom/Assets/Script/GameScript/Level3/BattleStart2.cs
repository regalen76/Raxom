using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStart2 : MonoBehaviour
{
    bool inside;
    public GameObject text;          //text untuk activate
    public GameObject textEnemy;    //text enemy diatas
    public GameObject Raxom;
    public GameObject Triggers;

    public GameObject firstEnemy;    //trigger boss
    BoxCollider2D firstEnemyCol;  //colnya
    Animator anim;  //animnya
    public GameObject enemyHealth;  //canvas healthnya

    private void Start()
    {
        firstEnemyCol = firstEnemy.GetComponent<BoxCollider2D>();
        anim = firstEnemy.GetComponent<Animator>();
        firstEnemyCol.enabled = false;
        enemyHealth.SetActive(false);
    }

    private void Update()
    {
        if (inside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager2>().Play("Level3 Theme");

                firstEnemy.GetComponent<AI>().enabled = true;
                firstEnemyCol.enabled = true;
                anim.SetTrigger("WakeUp");
                enemyHealth.SetActive(true);

                Raxom.gameObject.SetActive(false);
                Triggers.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inside = true;
            text.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inside = false;
            text.SetActive(false);
        }
        
    }
}
