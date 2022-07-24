using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portalend : MonoBehaviour
{
    bool inside;
    public GameObject text;
    private void Update()
    {
        if (inside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    SceneManager.LoadScene(4);
                }
                else if (SceneManager.GetActiveScene().buildIndex == 4){
                    SceneManager.LoadScene(5);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        inside = true;
        text.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
        text.SetActive(false);
    }
}
