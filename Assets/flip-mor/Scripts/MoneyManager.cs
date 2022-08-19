using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money;

    // Start is called before the first frame update
    void Start()
    {
        money = 1000000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }
    public void subtractMoney(int moneyToSubtract)
    {
        if(money - moneyToSubtract < 0)
        {
            return;
        }
        else
        {
            money -= moneyToSubtract;
        }
    }
}
