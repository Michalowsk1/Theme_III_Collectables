using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBossStage : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    public Transform spawn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Superbullet")
        {
            GameObject explosionClone = Instantiate(explosion, spawn.transform.position, Quaternion.identity);
            Controls.explosion.Play();
            Destroy(gameObject);
            Destroy(explosionClone, 1);
        }

        if(collision.gameObject.tag == "Remove")
        {
            Destroy(gameObject);
        }
    }
}
