using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject textEnemy;    //text enemy diatas

    public bool inAction;
    public bool ended;

    public int killed;
    public int enemytotal;

    public GameObject rune;
    public GameObject runechild;
    public GameObject platform;

    BattleStart2 battleStart;

    public static Level3 instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        if(PlayerPrefs.GetInt("selectedIndex") == 0)  //jika asassin hilangkan 1 platform
        {
            platform.SetActive(false);
        }
    }
    private void Start()
    {
        battleStart = GetComponent<BattleStart2>();
    }

    void Update()
    {
        if (killed == 1)
        {
            textEnemy.SetActive(false);
            rune.SetActive(true);
            runechild.SetActive(true);
        }
    }
}
