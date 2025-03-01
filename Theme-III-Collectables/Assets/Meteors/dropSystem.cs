using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropSystem : MonoBehaviour
{
    [SerializeField] GameObject[] lootDrops;
    [SerializeField] GameObject explosion;
    public Transform spawn;
    int health;
    int randspawn;
    public Animation destroy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        randspawn = Random.Range(0, lootDrops.Length);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health = Random.Range(1, 3);
        if (collision.gameObject.tag == "Bullet" && Controls.upgradeCount != 3) //doesnt spawn loot when in boss fight
        {
            health--;
            if (health == 0)
            {
                GameObject explosionClone = Instantiate(explosion, spawn.transform.position, Quaternion.identity);
                Controls.explosion.Play();
                Instantiate(lootDrops[randspawn], gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(explosionClone, 1);
            }

        }
        if (collision.gameObject.tag == "Superbullet" && Controls.upgradeCount != 3)
        {
            GameObject explosionClone = Instantiate(explosion, spawn.transform.position, Quaternion.identity);
            Controls.explosion.Play();
            Instantiate(lootDrops[randspawn], gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosionClone, 1);
        }

        if (collision.gameObject.tag == "Remove")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
