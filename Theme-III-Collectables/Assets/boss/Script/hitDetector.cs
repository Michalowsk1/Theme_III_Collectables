using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetector : MonoBehaviour
{
    [SerializeField] GameObject hitBoss;
    [SerializeField] CapsuleCollider2D collider;
    public static int hitCounter = 0;
    public int hitcount;
    public bool timerCheck;
    public float timer;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        hitBoss.SetActive(false);
        timerCheck = false;
    }
    void Update()
    {
        hitcount = hitCounter;

        if(timerCheck)
        {
            timer = timer + Time.deltaTime;
        }

        if (timer >= 0.05f) //changes sprite
        {

            timer = 0;
            timerCheck = false;
            hitBoss.SetActive(false);
        }

        if(bossBattle.boss) //allows boss to be hit after it spawns
        {
            collider.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //counts hits
    {
        if(collision.gameObject.tag == "Superbullet")
        {
            hitCounter++;
            timerCheck = true;
            hitBoss.SetActive(true);
        }
    }
}
