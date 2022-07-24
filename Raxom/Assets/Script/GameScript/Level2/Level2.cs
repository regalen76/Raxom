using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject textEnemy;    //text enemy diatas
    public GameObject malam;    //nyalakan malam
    public GameObject platform; //platform saat battle
    public GameObject leftBarrier;

    public GameObject activated2;
    public GameObject activated3; 

    public bool inAction;
    public bool ended;

    public int killed;
    public int enemytotal;

    public GameObject portal;

    public GameObject enemy2;

    BattleStart battleStart;

    public static Level2 instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        FindObjectOfType<AudioManager2>().Play("Level2 Theme");
        battleStart = GetComponent<BattleStart>();
    }

    void Update()
    {
        if (killed == 1)
        {
            enemy2.SetActive(true);
            activated2.SetActive(true);
        }
        if (killed == 2)
        {
            malam.SetActive(false);
            textEnemy.SetActive(false);
            leftBarrier.SetActive(false);
            platform.SetActive(false);
            portal.SetActive(true);
            activated3.SetActive(true);
        }
    }
}
