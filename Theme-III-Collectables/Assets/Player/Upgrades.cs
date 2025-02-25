using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    bool speedUpgrade = false;
    bool shotUpgrade = false;
    [SerializeField] GameObject UpgradedShot;
    public Transform shotSpawn;
    bool armourUpgrade = false;
    // Start is called before the first frame update
    void Start()
    {
        UpgradedShot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shotUpgrade == true && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(UpgradedShot, shotSpawn.position, Quaternion.identity);
        }
    }
}
