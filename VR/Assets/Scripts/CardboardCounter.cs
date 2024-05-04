using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardboardCounter : MonoBehaviour
{
    public TMP_Text cardboardText;
    public int cardboard;
    public GameObject congratsText;
    private void Start()
    {
        cardboardText.text = "Cardboard Count: " + cardboard;
    }
    void Update()
    {
        cardboardText.text = "Cardboard Count: " + cardboard;
        if(cardboard >= 10)
        {
            congratsText.SetActive(true);
        }
    }

    public void addCardboard()
    {
        cardboard += 1;
        cardboardText.text = "Cardboard Count: " + cardboard;
    }
    public int cardboardCount()
    {
        return cardboard;
    }
}
