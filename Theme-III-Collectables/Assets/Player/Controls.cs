using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Controls : MonoBehaviour
{
    [SerializeField] Rigidbody2D Ship;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI scoreText;
    public int horSpeed;
    public int verSpeed;
    public int score;
    public Transform bulletSpawn;
    public bool isplaying;
    //Start is called before the first frame update
    void Start()
    {
        Ship = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        score = 0;
        horSpeed = 4;   verSpeed = 2;
        isplaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString(); 

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Ship.velocity = new Vector2(moveHorizontal * horSpeed, moveVertical * verSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            
        }

        if (isplaying)
        {
            score = score + 1;
        }
        else  score = score + 0;

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
}
