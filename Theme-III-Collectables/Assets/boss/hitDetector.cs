using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetector : MonoBehaviour
{
    public static int hitCounter = 0;
    public int hitcount;

    void Update()
    {
        hitcount = hitCounter;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Superbullet")
        {
            hitCounter++;
        }
    }
}
