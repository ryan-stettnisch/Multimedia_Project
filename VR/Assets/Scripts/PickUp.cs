using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpText;
    public Transform objectHolder;
    public static Boolean currentlyHolding;
    private GameObject currentlyHeldObject;
    public GameObject ThrowOutText;
    public static GameObject currentGameObject;
    public MoneyCounter moneyCounter;

    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "Recycle" && other.gameObject.tag == "Player" && currentlyHolding)
        {
            ThrowOutText.SetActive(true);
            PickUpText.SetActive(false);
            if (Input.GetKey(KeyCode.F))
            {
                currentlyHolding = false;
                BoxCollider collider = currentGameObject.GetComponent<BoxCollider>();
                collider.enabled = false;
                Destroy(currentGameObject);
                ThrowOutText.SetActive(false);
                PickUpText.SetActive(false);
                moneyCounter.addMoney();
            }
        }
        else if (this.gameObject.tag == "Trash" && other.gameObject.tag == "Player" && !currentlyHolding)
        {
            PickUpText.SetActive(true);
            ThrowOutText.SetActive(false);
            if (Input.GetKey(KeyCode.E))
            {
                currentlyHolding = true;
                currentGameObject = this.gameObject;
                this.gameObject.transform.SetParent(objectHolder.transform);
                this.transform.localPosition = Vector3.zero;
                PickUpText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
        ThrowOutText.SetActive(false);
    }
    public GameObject heldGameObject()
    {
        return currentlyHeldObject;
    }
}
