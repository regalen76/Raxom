using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{

    public static Trigger2 instance;

    public GameObject theEnemy1;
    public GameObject theEnemy2;
    public GameObject theEnemy3;

    public GameObject enemyevent;
    public GameObject penghalang;
    public GameObject penghalang2;
    public int killed = 0;

    public float xpos1;
    public float xpos2;
    public float ypos;

    private float xPos;
    private float yPos;
    public int enemyCount;

    public float xpos1ke2;
    public float xpos2ke2;
    public float yposke2;

    private float xPoske2;
    private float yPoske2;

    private int index = 0;

    private bool triggerdisonce = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Level.instance.ended == true)
        {
            /*enemyevent.SetActive(false);*/
            /*Level.instance.inAction = false;*/
            penghalang.SetActive(false);
            penghalang2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            if (triggerdisonce == false)
            {
                /*enemyevent.SetActive(true);*/
                Level.instance.inAction = true;
                penghalang.SetActive(true);
                penghalang2.SetActive(true);
                Level.instance.enemytotal += enemyCount * 3;
                while (index < enemyCount)  //assassin
                {
                    xPos = Random.Range(xpos1, xpos2); //-60 071
                    yPos = ypos; //-2.19f
                    GameObject NewObject = Instantiate(theEnemy1, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, 0));
                    Rigidbody2D rb = NewObject.GetComponent<Rigidbody2D>();
                    rb.constraints = RigidbodyConstraints2D.None;
                    xPoske2 = Random.Range(xpos1ke2, xpos2ke2); //-60 071
                    yPoske2 = yposke2; //-2.19f
                    GameObject NewObject2 = Instantiate(theEnemy2, new Vector3(xPoske2, yPoske2, 0), Quaternion.Euler(0, 0, 0));
                    Rigidbody2D rb2 = NewObject2.GetComponent<Rigidbody2D>();
                    rb2.constraints = RigidbodyConstraints2D.None;
                    xPoske2 = Random.Range(xpos1ke2, xpos2ke2); //-60 071
                    yPoske2 = yposke2; //-2.19f
                    GameObject NewObject3 = Instantiate(theEnemy3, new Vector3(xPoske2, -1.57f, 0), Quaternion.Euler(0, 0, 0)); //attackbot = -1.57f
                    Rigidbody2D rb3 = NewObject3.GetComponent<Rigidbody2D>();
                    rb3.constraints = RigidbodyConstraints2D.None;
                    index++;
                }
            }
            triggerdisonce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

        }
    }
}
