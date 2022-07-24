using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    // Start is called before the first frame update

    private int index = 0;
    public Image selected;
    public Image selected2;

    public GameObject canvas2;

    void Start()
    {
        index = 0;
        PlayerPrefs.SetInt("SelectedMenu", index);
        selected.enabled = true;
        selected2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FindObjectOfType<AudioManager>().Play("UI");
            BackOption();
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindObjectOfType<AudioManager>().Play("UI");
            NextOption();
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Play("UI");
            if (index == 0)
            {
                SceneManager.LoadScene(1);
            } else if(index == 1)
            {
                this.gameObject.SetActive(false);
                canvas2.SetActive(true);
            }
        }

        if(index == 0)
        {
            selected.enabled = true;
            selected2.enabled = false;
        } else if(index == 1)
        {
            selected.enabled = false;
            selected2.enabled = true;
        }
    }

    public void NextOption()
    {
        index++;

        if (index >= 2)
        {
            index = 0;
        }

        PlayerPrefs.SetInt("SelectedMenu", index);
    }

    public void BackOption()
    {
        index--;

        if (index < 0)
        {
            index = 2 - 1;
        }

        PlayerPrefs.SetInt("SelectedMenu", index);
    }
}
