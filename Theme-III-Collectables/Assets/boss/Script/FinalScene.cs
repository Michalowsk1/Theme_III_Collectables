using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] GameObject mainGame;
    [SerializeField] GameObject endScene;
    [SerializeField] GameObject endCutscene;
    [SerializeField] GameObject FinalLaser;
    [SerializeField] GameObject FinalLaserRepeat;
    [SerializeField] GameObject explosion;
    public Transform explosionArea;
    public AudioSource LaserAudio;
    public AudioSource bossExplosion;
    public static bool bossDefeated;
    public int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainGame.SetActive(true);
        endScene.SetActive(false);
        endCutscene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(bossDefeated)
        {
            mainGame.SetActive(false);
            endScene.SetActive(true);
            FinalLaser.SetActive(true);
            DestroyBoss();
        }
    }

    public void DestroyBoss()
    {
        timer++;
        if (timer >= 800)
        {
            FinalLaser.SetActive(false);
            //FinalLaserRepeat.SetActive(true);
            explosion.transform.position = new Vector2(explosionArea.position.x - 0.5f, explosionArea.position.y - 3);
            endCutscene.SetActive(true);
            
        }
        
    }

    IEnumerator waitforLaser()
    {
        yield return new WaitForSeconds(9);
        bossExplosion.Play();
    }
}
