using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropSystem : MonoBehaviour
{
    [SerializeField] GameObject[] lootDrops;
    int health = 2;
    int randspawn;

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
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            if (health == 0)
            {
                Instantiate(lootDrops[randspawn], gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.tag == "Superbullet")
        {
            Instantiate(lootDrops[randspawn], gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
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
