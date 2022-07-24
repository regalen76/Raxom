using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu_run1 : MonoBehaviour
{
    public float cycleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(16f, cycleSpeed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 15)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (transform.position.x <= -17)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
