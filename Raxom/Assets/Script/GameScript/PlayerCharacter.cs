using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;

    private int selectedIndex = 0;

    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim2;

    // Start is called before the first frame update
    void Start()
    {
        /*this.GetComponent<Animator>().runtimeAnimatorController = anim1 as RuntimeAnimatorController;*/

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
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedIndex);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedIndex = PlayerPrefs.GetInt("selectedIndex");
    }
}
