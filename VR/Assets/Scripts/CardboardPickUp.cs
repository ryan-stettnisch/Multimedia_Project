using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CardboardText;
    public CardboardCounter cardboardcounter;
    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "Cardboard" && other.gameObject.tag == "Player")
        {
            CardboardText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                cardboardcounter.addCardboard();
                CardboardText.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CardboardText.SetActive(false);
    }
}