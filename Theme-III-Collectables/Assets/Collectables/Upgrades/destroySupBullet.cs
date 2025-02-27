using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySupBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Screwdriver" || collision.gameObject.tag == "Gas" || collision.gameObject.tag == "Fuel")
        {
            Destroy(gameObject);
        }
    }
}
