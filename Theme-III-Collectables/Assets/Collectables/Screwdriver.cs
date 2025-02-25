using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Screwdriver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] GameObject Item;
    [SerializeField] GameObject ChargeBullet;
    public int count;
    public Button purchase;
    private bool purchased;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        purchase.enabled = false;
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString() + "/10";
        if (count == 10)
        {
            purchase.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            count++;
        }
    }

    public void Purchase()
    {
        Item.SetActive(true);
        Controls.upgrade = 1;
        count = 0;
    }


}
