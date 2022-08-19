using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [Header("Money UI")]
    [SerializeField] private TextMeshProUGUI moneyText;

    public string money;
    public string price;
    public string salePrice;

    private Renderer moneyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        moneyRenderer = GetComponentInChildren<Renderer>();
        // money = 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        money = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("moneyCount")).value;
        price = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("price")).value;
        salePrice = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("salePrice")).value;
        moneyText.text = (Convert.ToDouble(money) - Convert.ToDouble(price) + Convert.ToDouble(salePrice)).ToString();
        // money = Convert.ToDouble(moneyText.text);
    }
    //public void addMoney(int moneyToAdd)
    //{
    //    money += moneyToAdd;
    //}
    //public void subtractMoney(int moneyToSubtract)
    //{
    //    if(money - moneyToSubtract < 0)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        money -= moneyToSubtract;
    //    }
    //}
}
