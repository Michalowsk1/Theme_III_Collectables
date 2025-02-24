using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] meteors;
    public float timer;
    public int meteorTimer;
    Vector2 spawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        meteorTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        spawn = new Vector2( Random.Range(-7, 7), Random.Range(6,8));

        if(timer > 0 )
        {
            timer -=Time.deltaTime;
        }

        else
        {
            int meteor = Random.Range(0,meteors.Length);
            Instantiate(meteors[meteor], spawn, Quaternion.identity);

            timer = Random.Range(1, meteorTimer);
        }
    }
}
