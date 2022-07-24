using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    private int index = 0;
    public Image selected;
    public Image selected2;

    void Start()
    {
        selected.enabled = true;
        selected2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            BackOption();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            NextOption();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (index == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (index == 1)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (index == 0)
        {
            selected.enabled = true;
            selected2.enabled = false;
        }
        else if (index == 1)
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
    }

    public void BackOption()
    {
        index--;

        if (index < 0)
        {
            index = 2 - 1;
        }
    }
}
