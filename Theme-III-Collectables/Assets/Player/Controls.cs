using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Controls : MonoBehaviour
{
    [SerializeField] Rigidbody2D Ship;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gameOver;
    public int horSpeed;
    public int verSpeed;
    public Transform bulletSpawn;

     //Start is called before the first frame update
    void Start()
    {
        Ship = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        horSpeed = 4;
        verSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Ship.velocity = new Vector2(moveHorizontal * horSpeed, moveVertical * verSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            
        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
