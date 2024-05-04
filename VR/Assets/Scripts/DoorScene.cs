using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LeaveHouseText;
    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "ApartmentDoor" && other.gameObject.tag == "Player")
        {
            LeaveHouseText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                LeaveHouseText.SetActive(false);
                SceneManager.LoadScene("City");
            }
        }
        else if (this.gameObject.tag == "GoBack" && other.gameObject.tag == "Player")
        {
            LeaveHouseText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                LeaveHouseText.SetActive(false);
                SceneManager.LoadScene("MainScene");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        LeaveHouseText.SetActive(false);
    }
}
