using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasPipe : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI purchaseText;
    public static int count;
    public Button purchase;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void Purchase()
    {
        Controls.incValue = 0.025f;
        Controls.decValue = 0.1f;
        purchase.enabled = false;
        purchaseText.text = "Purchased";

    }
}
