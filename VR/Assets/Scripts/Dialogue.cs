using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private bool currentlyTalking;
    public GameObject DialogueText;
    public AudioSource DialogueAudio;
    public MoneyCounter moneyCounter;

    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "NPC" && other.gameObject.tag == "Player" && !currentlyTalking)
        {
            DialogueText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                currentlyTalking = true;
                DialogueAudio.Play();
                DialogueText.SetActive(false);
                moneyCounter.addMoney();
                Invoke("OnAudioFinished", DialogueAudio.clip.length);
            }
        }
    }
    void OnAudioFinished()
    {
        currentlyTalking = false;
    }
    private void OnTriggerExit(Collider other)
    {
        DialogueText.SetActive(false);
    }
}
