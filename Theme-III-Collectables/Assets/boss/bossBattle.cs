using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class bossBattle : MonoBehaviour
{
    int timer;


    [Header("GameObjects")]
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject EnemyShot;
    [SerializeField] GameObject[] Meteors;
    [SerializeField] GameObject[] Meteors1;
    [SerializeField] GameObject endScene;
    [SerializeField] TextMeshProUGUI LaserChargeText;
    Vector2 MeteorSpawnExtra;
    Vector2 MeteorSpawnLeft;
    Vector2 MeteorSpawnRight;
    int chargePower;
    public bool boss;
    public bool stage1;
    public bool stage2;
    [Header("Bullets")]
    public Transform stage1Spawn;
    public int spawntime = 0;
    public int meteorSpawner = 0;
    int meteorArray;
    int meteorArray1;
    // Start is called before the first frame update
    void Start()
    {
        boss = false;
        stage1 = true;
        stage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        StageSwitcher();
        if (Controls.upgradeCount == 3)
        {
            CutsceneTimer();
            boss = true;
        }


        if (boss && CutsceneTimer())
        {
            BulletSpawner();
            AsteroidSpawner();
        }
    }

    public void BulletSpawner()
    {
        spawntime++;
        if(stage1)
        {
            if (spawntime >= 90)
            {
                Instantiate(EnemyShot, stage1Spawn.position, Quaternion.identity);
                spawntime = 0;
            }

        }

        if(stage2)
        {
            if (spawntime >= 60)
            {
                Instantiate(EnemyShot, stage1Spawn.position, Quaternion.identity);
                spawntime = 0;
            }
        }
    }

    private void AsteroidSpawner()
    {
        MeteorSpawnLeft = new Vector2(Random.Range(-6, 0), Random.Range(6, 8));
        MeteorSpawnRight = new Vector2(Random.Range(0, 6), Random.Range(6, 8));
        MeteorSpawnExtra = new Vector2(Random.Range(-6, 6), Random.Range(6, 8));
        meteorArray = Random.Range(0, Meteors.Length);
        meteorArray1 = Random.Range(0, Meteors.Length);
        meteorSpawner++;
        if (stage1)
        {
            if (meteorSpawner >= 200)
            {
                Instantiate(Meteors[meteorArray], MeteorSpawnLeft, Quaternion.identity);
                Instantiate(Meteors[meteorArray1], MeteorSpawnRight, Quaternion.identity);
                meteorSpawner = 0;
            }

        }

        if (stage2)
        {
            if (meteorSpawner >= 120)
            {
                Instantiate(Meteors[meteorArray], MeteorSpawnLeft, Quaternion.identity);
                Instantiate(Meteors[meteorArray1], MeteorSpawnRight, Quaternion.identity);
                Instantiate(Meteors[meteorArray], MeteorSpawnExtra, Quaternion.identity);
                meteorSpawner = 0;
            }
        }
    }

    public void DamageBoss()
    {

    }

    public void StageSwitcher()
    {
        if(chargePower >= 50)
        {
            stage1 = false;
            stage2 = true;
        }
    }

    public bool CutsceneTimer()
    {
        timer++;
        if (timer >= 600)
        {
            return true;
        }
        return false;
    }
}
