using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{

    SpriteRenderer sprite;
    BoxCollider2D col;
    float alpha = 1f;
    bool standing;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(standing == false)
        {
            Color c = sprite.color;
            alpha += 0.0009f;
            if(alpha > 1f)
            {
                alpha = 1f;
            }
            c.a = alpha;
            sprite.color = c;
        }

        if (standing == true)
        {
            Color c = sprite.color;
            alpha -= 0.004f;
            c.a = alpha;
            sprite.color = c;
        }

        if (sprite.color.a > 0.8)
        {
            col.enabled = true;
        }

        if(sprite.color.a < 0.04)
        {
            col.enabled = false;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Fade());
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            standing = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            standing = false;
        }
    }

    /*IEnumerator Back()
    {
        yield return new WaitForSeconds(4f);
        alpha = 1f; 
        col.enabled = true;
        Color c = sprite.color;
        c.a = 1f;
        sprite.color = c;
    }

    IEnumerator Fade()
    {
        Color c = sprite.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.04f)
        {
            c.a = alpha;
            sprite.color = c;
            yield return new WaitForSeconds(.1f);
        }
    }*/
}
