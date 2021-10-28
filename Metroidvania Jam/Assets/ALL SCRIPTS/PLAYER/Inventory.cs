using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    static int money=0;
    private TextMeshProUGUI CoinsDisplay;
    int displayMoney;

    private void Start()
    {
        CoinsDisplay = GameObject.Find("CoinsText").GetComponent<TextMeshProUGUI>();
    }

    public void GetMoney()
    {
        money++;
    }

    private void Update()
    {
        displayMoney = money;
        CoinsDisplay.text = displayMoney.ToString();
    }
}
