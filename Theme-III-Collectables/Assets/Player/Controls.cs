using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Controls : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] Rigidbody2D Ship;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI scoreText;
    [Header("Movement")]
    public int horSpeed;
    public int verSpeed;
    [Header("Shooting")]
    public int score;
    float timer;
    public Transform bulletSpawn;
    public bool isplaying;
    public bool canShoot = true;
    [Header("Overheating")]
    [SerializeField] GameObject FillBar;
    public float incValue = 0.05f;
    public float decValue = 0.05f;
    //Start is called before the first frame update
    void Start()
    {
        Ship = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        score = 0;
        horSpeed = 4;   verSpeed = 3;
        isplaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        OverHeating();
        scoreText.text =  "Score: " + score.ToString(); 

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Ship.velocity = new Vector2(moveHorizontal * horSpeed, moveVertical * verSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            
        }

        if (isplaying)
        {
            scoreCounter();
        }
        else { }

    }


    private void OverHeating()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
            {
                FillBar.transform.localScale = new Vector3(FillBar.transform.localScale.x + incValue, FillBar.transform.localScale.y);
            }

            if (FillBar.transform.localScale.x > 0.25f)
            {
            canShoot = false;
            StartCoroutine(decHeating());
        }

            else if (FillBar.transform.localScale.x >= 0.01f)
            {
                FillBar.transform.localScale = new Vector3(FillBar.transform.localScale.x - (decValue * Time.deltaTime), FillBar.transform.localScale.y);
            }

            else if (FillBar.transform.localScale.x <= 0.01f)
            {
                canShoot = true;
            }
        }
    }

    private void scoreCounter()
    {
        timer = timer + Time.deltaTime;
        if(timer >= 0.4)
        {
            score++;
            timer = 0;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            isplaying = false;
        }
    }

    IEnumerator decHeating()
    {
        yield return new WaitForSeconds(1);
        FillBar.transform.localScale = new Vector3(FillBar.transform.localScale.x - (decValue * Time.deltaTime), FillBar.transform.localScale.y);
    }
}



