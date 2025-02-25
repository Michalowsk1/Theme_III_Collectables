using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDestroy : MonoBehaviour
{
    int health = 2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
            if(health == 0)
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Superbullet")
        {
                Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Remove")
        {
            Destroy(gameObject);
        }
    }
}
