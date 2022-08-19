using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [Header("Money UI")]
    [SerializeField] private TextMeshProUGUI moneyText;

    public string money;

    private Renderer moneyRenderer;
    // Start is called before the first frame update
    void Start()
    {
        moneyRenderer = GetComponentInChildren<Renderer>();
        money = "0.5";
    }

    // Update is called once per frame
    void Update()
    {
        money = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("moneyCount")).value;
        moneyText.text = money;
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
