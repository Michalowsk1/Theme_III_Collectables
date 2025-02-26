using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class remove : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Remove")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Superbullet")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Screwdriver" || collision.gameObject.tag == "Fuel" || collision.gameObject.tag == "Gas")
        {
            Destroy(gameObject);
        }
    }
}
