using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public bool Stop = false;

    private void Update()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (this.gameObject.name == "Boss")
        {
            if (transform.position.x > player.position.x && isFlipped && Trigger3Boss.Instance.inside == true)  //dikiri si boss
            {
                Trigger3Boss.Instance.inside = false;
                Enemy.instance.animator.SetTrigger("turnleft");
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped  && Trigger3Boss.Instance.inside == true)   //dikanan si boss
            {
                Trigger3Boss.Instance.inside = false;
                Enemy.instance.animator.SetTrigger("turnright");
                isFlipped = true;
                
            }
        }
    }

    public void BossCollider1()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.97f, 1.74363f);
    }

    public void BossCollider2()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.9430161f, 1.74363f);
    }

    public void LookAtPlayer(){  //enemy
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(this.gameObject.name == "Boss")
        {
            /*if (transform.position.x > player.position.x && isFlipped)  //dikiri si boss
            {
                if(Trigger3Boss.Instance.inside == true)
                {
                    Enemy.instance.animator.SetTrigger("turnright");
                }
            }
            else if (transform.position.x < player.position.x && !isFlipped)   //dikanan si boss
            {
                if (Trigger3Boss.Instance.inside == true)
                {
                    Enemy.instance.animator.SetTrigger("turnleft");
                }
            }*/
        }
        else
        {
            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player" || col.gameObject.name == "stops")
        {
            Stop = true;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player" || col.gameObject.name == "stops")
        {
            Stop = false;
            
        }
    }

}
