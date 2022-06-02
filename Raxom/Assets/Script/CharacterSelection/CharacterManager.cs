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
    // Start is called before the first frame update
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
