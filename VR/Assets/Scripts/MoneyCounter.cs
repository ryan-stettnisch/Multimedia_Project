using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public TMP_Text moneyText;
    public int money;
    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void addMoney()
    {
        money += 10;
        moneyText.text = money.ToString();
    }
    public int returnMoney()
    {
        return money;
    }
    public void subtract()
    {
        money -= 100;
    }
        
}
