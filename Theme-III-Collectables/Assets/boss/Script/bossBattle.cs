using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class bossBattle : MonoBehaviour
{
    //public static int timer;


    [Header("GameObjects")]
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemyShot;
    [SerializeField] GameObject[] Meteors;
    [SerializeField] GameObject[] Meteors1;
    //[SerializeField] GameObject endScene;
    [SerializeField] GameObject loot;
    Vector2 MeteorSpawnExtra;
    Vector2 MeteorSpawnLeft;
    Vector2 MeteorSpawnRight;
    Vector2 LootSpawn;
    public static bool boss;
    public bool stage1;
    public bool stage2;
    [Header("Bullets")]
    public Transform stage1Spawn;
    public int spawntime = 0;
    [Header("Meteor")]
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
            StartCoroutine(BossCutscene());
        }


        if (boss)
        {
            BulletSpawner();
            AsteroidSpawner();
            DamageBoss();
        }


        if(LaserCharge.batteryLevel >= 4)
        {
            FinalScene.bossDefeated = true;
        }
    }

    public void BulletSpawner()
    {
        spawntime++;
        if(stage1)
        {
            if (spawntime >= 180)
            {
                GameObject projectile = Instantiate(EnemyShot, stage1Spawn.position, Quaternion.identity);
                spawntime = 0;

                if(!boss)
                {
                    Destroy(projectile);
                }
            }

        }

        else if(stage2)
        {
            if (spawntime >= 120)
            {
                GameObject projectile = Instantiate(EnemyShot, stage1Spawn.position, Quaternion.identity);
                spawntime = 0;

                if (!boss)
                {
                    Destroy(projectile);
                }
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
            if (meteorSpawner >= 250)
            {
                GameObject meteor = Instantiate(Meteors[meteorArray], MeteorSpawnLeft, Quaternion.identity);
                GameObject meteor1 = Instantiate(Meteors[meteorArray1], MeteorSpawnRight, Quaternion.identity);
                meteorSpawner = 0;

                if(!boss)
                {
                    Destroy(meteor);
                    Destroy(meteor1);
                }
            }
        }

        else if (stage2)
        {
            if (meteorSpawner >= 250)
            {
                GameObject meteor = Instantiate(Meteors[meteorArray], MeteorSpawnLeft, Quaternion.identity);
                GameObject meteor1 = Instantiate(Meteors[meteorArray1], MeteorSpawnRight, Quaternion.identity);
                GameObject meteor2 = Instantiate(Meteors[meteorArray], MeteorSpawnExtra, Quaternion.identity);
                meteorSpawner = 0;

                if (!boss)
                {
                    Destroy(meteor);
                    Destroy(meteor1);
                    Destroy(meteor2);
                }
            }
        }
    }

    public void DamageBoss()
    {
        LootSpawn = new Vector2(Random.Range(-6, 6), Random.Range(6, 8));
        int hitRequirement = Random.Range(15, 30);
        if(hitDetector.hitCounter >= hitRequirement)
        {
            Instantiate(loot, LootSpawn, Quaternion.identity);
            hitDetector.hitCounter = 0;
        }
    }

    public void StageSwitcher()
    {
        if(LaserCharge.batteryLevel >= 3)
        {
            stage1 = false;
            stage2 = true;
        }
        else
        {
            stage1 = true;
            stage2 = false;
        }
    }

    IEnumerator BossCutscene()
    {
        yield return new WaitForSeconds(9);
        boss = true;

    }
}
