using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fuelTank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI purchaseText;
    [SerializeField] GameObject soldOutText;
    public AudioSource purchased;
    public static int count;
    public Button purchase;
    // Start is called before the first frame update
    void Start()
    {
        soldOutText.SetActive(false);
        count = 0;
        purchase.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count + "/5";
        if (count >= 5)
        {
            purchase.enabled = true;
            count = 5;
        }

        if(Controls.horSpeed == 6)
        {
            purchase.enabled = false;
        }
    }

    public void Purchase()
    {
        purchased.Play();
        soldOutText.SetActive(true);
        Controls.horSpeed = 6;
        purchaseText.text = "Purchased";
        Controls.upgradeCount++;

    }
}
