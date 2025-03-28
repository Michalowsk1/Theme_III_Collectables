using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    public float timer;
    public static int meteorTimer;
    Vector2 leftSpawn;
    Vector2 rightSpawn;
    //[SerializeField] Transform Spawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        meteorTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controls.upgradeCount != 3)
        {


            leftSpawn = new Vector2(Random.Range(-6, 0), Random.Range(6, 10));
            rightSpawn = new Vector2(Random.Range(0, 4), Random.Range(6, 10));

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            else
            {
                int meteor = Random.Range(0, meteors.Length);
                int meteor1 = Random.Range(0, meteors.Length);

                Instantiate(meteors[meteor], leftSpawn, Quaternion.identity);
                Instantiate(meteors[meteor1], rightSpawn, Quaternion.identity);

                timer = Random.Range(0.5f, meteorTimer);
            }
        }
        else { }
    }
}
