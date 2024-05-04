using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnGoldBike : MonoBehaviour
{
    public MoneyCounter counter;
    public GameObject GetOnBikeText;
    public GameObject GetOffBikeText;
    public GameObject NotEnoughMoneyText;
    public bool currentlyOn;
    public Transform person;
    public Transform bike_seat;
    public Movement playerMovement;
    private bool canBuy, boughtTrue, left;
    public GameObject BuyBikeText;

    // Start is called before the first frame update



    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "GoldenBike" && other.gameObject.tag == "Player" && counter.returnMoney() < 100 & !canBuy)
        {
            NotEnoughMoneyText.SetActive(true);
        }
        else if (this.gameObject.tag == "GoldenBike" && other.gameObject.tag == "Player" && counter.returnMoney() >= 100 && (!canBuy || left))
        {
            NotEnoughMoneyText.SetActive(false);
            BuyBikeText.SetActive(true);
            canBuy = true;

            if (this.gameObject.tag == "GoldenBike" && other.gameObject.tag == "Player" && canBuy && counter.returnMoney() >= 100 && Input.GetKey(KeyCode.E))
            {
                BuyBikeText.SetActive(false);
                boughtTrue = true;
                counter.subtract();
            }
        }

        else
        {
            if (this.gameObject.tag == "GoldenBike" && other.gameObject.tag == "Player" && !currentlyOn && boughtTrue)
            {
                GetOnBikeText.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    currentlyOn = true;
                    GetOnBikeText.SetActive(false);
                    OnBike();
                    GetOffBikeText.SetActive(true);

                }
            }
            else if (this.gameObject.tag == "GoldenBike" && other.gameObject.tag == "Player" && currentlyOn && boughtTrue)
            {
                GetOffBikeText.SetActive(true);
                if (Input.GetKey(KeyCode.F) && currentlyOn)
                {
                    currentlyOn = false;
                    GetOffBikeText.SetActive(false);
                    OffBike();
                    GetOnBikeText.SetActive(true);
                }
            }
        }
    }
    private void OnBike()
    {
        person.SetParent(bike_seat);
        person.localPosition = Vector3.zero; // Adjust as necessary //Vector3.zero
        person.localRotation = Quaternion.identity;// Adjust as necessary //Quaternion.identity
        playerMovement.enabled = false;
        //carMovement.enabled = true;
    }

    private void OffBike()
    {
        // carMovement.enabled = false;
        playerMovement.enabled = true;
        person.SetParent(null);
    }
    private void OnTriggerExit(Collider other)
    {
        GetOnBikeText.SetActive(false);
        GetOffBikeText.SetActive(false);
        NotEnoughMoneyText.SetActive(false);
        BuyBikeText.SetActive(false);
        left = true;
    }
}

