using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossDropLoot : MonoBehaviour
{
    
    public static bool collected;
    // Start is called before the first frame update
    void Start()
    {
        collected = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collected = true;
            Destroy(gameObject);
        }
    }
}
