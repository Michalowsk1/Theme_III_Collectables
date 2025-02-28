using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBattle : MonoBehaviour
{
    [Header("GameObjects")]

    [Header("Animation")]
    private bool boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Controls.upgradeCount == 3)
        {
            boss = true;
        }


        if(boss)
        {

        }
    }
}
