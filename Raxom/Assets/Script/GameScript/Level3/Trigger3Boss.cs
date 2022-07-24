using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3Boss : MonoBehaviour
{

    public bool inside;
    float Rotation = 180;

    public Transform triggers;

    public static Trigger3Boss Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inside = true;
            if(inside == true && Rotation == 180)
            {
                Rotation = 0;
                triggers.Rotate(0f, 180f, 0f);
                triggers.position += new Vector3(13.76f, 0, 0);
            } else if (inside == true && Rotation == 0)
            {
                Rotation = 180;
                triggers.Rotate(0f, 180f, 0f);
                triggers.position += new Vector3(-13.76f, 0, 0);
            }
        }
    }
}
