using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LaserCharge : MonoBehaviour
{
    [SerializeField] GameObject[] BatteryCharge;
    public static int batteryLevel;
    // Start is called before the first frame update
    void Start()
    {
        batteryLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDropLoot.collected)
        {
            for (int i = 1; i < 2; i++)
            {
                batteryLevel++;
                BatteryCharge[batteryLevel].SetActive(true);
                bossDropLoot.collected = false;
                i = 1;
            }
        }
    }
}
