using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOnBike : MonoBehaviour
{
    public bool currentlyOn;
    public Transform person;
    public GameObject GetOnBikeText;
    public GameObject GetOffBikeText;
    public GameObject GetInCarText;
    public GameObject GetOutCarText;
    public Movement playerMovement;
    //public CarMovement carMovement;
    public Transform bike_seat;
    public Camera mainCamera;
    public GameObject person2;
    public Camera car_camera;


    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "Bicycle"  && other.gameObject.tag == "Player" && !currentlyOn)
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
        else if (this.gameObject.tag == "Bicycle"  && other.gameObject.tag == "Player" && currentlyOn)
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
        else if(this.gameObject.tag == "Car" && other.gameObject.tag == "Player" && !currentlyOn)
        {
            GetInCarText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                currentlyOn = true;
                GetInCarText.SetActive(false);
                InCar();
                GetOutCarText.SetActive(true);

            }
        }
        else if(this.gameObject.tag == "Car" && other.gameObject.tag == "Player" && currentlyOn)
        {
            GetOutCarText.SetActive(true);
            if (Input.GetKey(KeyCode.F) && currentlyOn)
            {
                currentlyOn = false;
                GetOutCarText.SetActive(false);
                OutCar();
                GetOnBikeText.SetActive(true);
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
        GetInCarText .SetActive(false);
        GetOutCarText .SetActive(false);
    }
    private void InCar()
    {
        mainCamera.gameObject.SetActive(false);
        car_camera.gameObject.SetActive(true);
        person2.SetActive(false);

    }
    private void OutCar()
    {
        car_camera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        person2.SetActive(true);
    }
}
