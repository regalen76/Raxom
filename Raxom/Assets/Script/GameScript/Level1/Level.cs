using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public bool inAction;
    public bool ended;

    public int killed;
    public int enemytotal;

    public GameObject enemyevent;
    public GameObject portal;

    public static Level instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FindObjectOfType<AudioManager2>().Play("Level1 Theme");
    }

    void Update()
    {
        if(killed != enemytotal && killed != 0)
        {
            ended = false;
        }
        if(killed == enemytotal && killed!=0)
        {
            ended = true;
        }
        if (killed != enemytotal)
        {
            enemyevent.SetActive(true);
        }
        if (killed == enemytotal)
        {
            enemyevent.SetActive(false);
        }

        if(killed == 46)
        {
            portal.SetActive(true);
        }
    }
}
