using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bossBattle : MonoBehaviour
{
    int timer;


    [Header("GameObjects")]
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject EnemyShot;
    [SerializeField] GameObject[] Meteors;
    [SerializeField] GameObject endScene;
    [SerializeField] TextMeshProUGUI LaserChargeText;
    Vector2 MeteorSpawn;
    [Header("Animation")]
    public bool boss;
    public bool stage1;
    public bool stage2;
    [Header("Bullets")]
    public Transform stage1Spawn;
    public int spawntime = 0;
    public int meteorSpawner = 0;
    int meteorArray;
    int hitCount;
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
                GameObject bullet = Instantiate(EnemyShot, stage1Spawn.position, Quaternion.identity);
                spawntime = 0;
            }

        }

        if(stage2)
        {
            if (spawntime >= 60)
            {
                GameObject bullet = Instantiate(EnemyShot, stage1Spawn.position, Quaternion.identity);
                spawntime = 0;
            }
        }
    }

    private void AsteroidSpawner()
    {
        MeteorSpawn = new Vector2(Random.Range(1, 14), 7);
        meteorArray = Random.Range(0, Meteors.Length);
        meteorSpawner++;
        if (stage1)
        {
            if (meteorSpawner >= 200)
            {
                GameObject meteor = Instantiate(Meteors[meteorArray], MeteorSpawn, Quaternion.identity);
                meteorSpawner = 0;
            }

        }

        if (stage2)
        {
            if (meteorSpawner >= 120)
            {
                GameObject meteor = Instantiate(Meteors[meteorArray], MeteorSpawn, Quaternion.identity);
                meteorSpawner = 0;
            }
        }
    }

    public void DamageBoss()
    {

    }

    public void StageSwitcher()
    {

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
