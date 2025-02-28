using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Screwdriver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI purchaseText;
    [SerializeField] GameObject soldOutText;
    [SerializeField] GameObject Item;
    [SerializeField] GameObject ChargeBullet;
    public AudioSource purchased;
    public static int count;
    public Button purchase;
    // Start is called before the first frame update
    void Start()
    {
        soldOutText.SetActive(false);
        count = 0;
        purchase.enabled = false;
        Item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString() + "/5";
        if (count >= 5)
        {
            purchase.enabled = true;
            count =5;
        }
        if(Controls.upgrade == 1)
        {
            purchase.enabled = false;
        }
    }
    public void Purchase()
    {
        purchased.Play();
        soldOutText.SetActive(true);
        Item.SetActive(true);
        Controls.upgrade = 1;
        Controls.upgradeCount++;
        purchaseText.text = "Purchased";

    }


}
