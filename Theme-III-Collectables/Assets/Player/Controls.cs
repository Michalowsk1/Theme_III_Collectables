using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Controls : MonoBehaviour
{
    [SerializeField] Rigidbody2D Ship;
    public int horSpeed;
    public int verSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Ship = GetComponent<Rigidbody2D>();
        horSpeed = 4;
        verSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Ship.velocity = new Vector2(moveHorizontal * horSpeed, moveVertical * verSpeed);
    }
}
