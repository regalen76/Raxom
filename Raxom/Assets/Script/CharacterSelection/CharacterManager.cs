using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedIndex = 0;

    public int maxStats = 100;  //slider
    public StatsBar statsBar;
    public StatsBar statsBar2;
    public StatsBar statsBar3;

    public Image tab1, tab2;  //tab stats atau skill
    private int tab = 0;
    public GameObject stats;
    public GameObject skill;

    public GameObject assassinSkill;  //display skill
    public GameObject mageSkill;

    public GameObject assassinSkill2;
    public GameObject mageSkill2;

    public GameObject difficulty1;
    public GameObject difficulty2;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedIndex"))
        {
            selectedIndex = 0; 
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedIndex);

        statsBar.SetMaxStats(maxStats);
        statsBar2.SetMaxStats(maxStats);
        statsBar3.SetMaxStats(maxStats);

        tab1.enabled = false;
        tab2.enabled = false;

        stats.SetActive(false);
        skill.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))  //change chara ke kiri
        {
            FindObjectOfType<AudioManager>().Play("UI");
            BackOption();
        } else if (Input.GetKeyDown(KeyCode.RightArrow))  // change chara ke kanan
        {
            FindObjectOfType<AudioManager>().Play("UI");
            NextOption();
        } else if (Input.GetKeyDown(KeyCode.D))  //play
        {
            FindObjectOfType<AudioManager>().Play("UI");
            if (PlayerPrefs.GetInt("SelectedMenu") == 0)  //play level 1
            {
                ChangeScene(3);
            }
        }

        if(selectedIndex == 0) //jika assassin
        {
            statsBar.SetStats(50); //damage
            statsBar2.SetStats(80); //speed
            statsBar3.SetStats(20); //range
            difficulty1.SetActive(true);
            difficulty2.SetActive(false);
        }
        if (selectedIndex == 1) //jika assassin
        {
            statsBar.SetStats(70); //damage
            statsBar2.SetStats(30); //speed
            statsBar3.SetStats(75); //range
            difficulty1.SetActive(false);
            difficulty2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FindObjectOfType<AudioManager>().Play("UI");
            if (tab == 0)
            {
                tab =1;
            }else if(tab == 1)
            {
                tab = 0;
            }
        }

        if(tab == 0)
        {
            tab1.enabled = true;
            tab2.enabled = false;

            stats.SetActive(true);
            skill.SetActive(false);

            mageSkill.SetActive(false);
            assassinSkill.SetActive(false);
            assassinSkill2.SetActive(false);
            mageSkill2.SetActive(false);

        } else if(tab == 1)
        {
            tab2.enabled = true;
            tab1.enabled = false;

            skill.SetActive(true);
            stats.SetActive(false);

            if(selectedIndex == 0)
            {
                mageSkill.SetActive(false);
                assassinSkill.SetActive(true);
                assassinSkill2.SetActive(true);
                mageSkill2.SetActive(false);
            }
            else if(selectedIndex == 1)
            {
                mageSkill.SetActive(true);
                assassinSkill.SetActive(false);
                assassinSkill2.SetActive(false);
                mageSkill2.SetActive(true);
            }
            
        }
    }

    public void NextOption()
    {
        selectedIndex++;

        if(selectedIndex >= characterDB.CharacterCount)
        {
            selectedIndex = 0;
        }

        UpdateCharacter(selectedIndex);
        Save();
    }

    public void BackOption()
    {
        selectedIndex--;

        if(selectedIndex < 0)
        {
            selectedIndex = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedIndex);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedIndex);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedIndex = PlayerPrefs.GetInt("selectedIndex");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedIndex", selectedIndex);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
