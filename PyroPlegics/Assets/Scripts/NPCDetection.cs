using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDetection : MonoBehaviour
{
    public GameObject dialogueTemplate;
    public GameObject canva;
    bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in range and presses the E key to start dialogue
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.readyToDialgoue)
        {
            // Start the dialogue
            canva.SetActive(true);
            PlayerMovement.readyToDialgoue = true;

            // Initialize the dialogue system in the NextDialogue script
            var nextDialogue = canva.GetComponentInChildren<NextDialogue>();
            if (nextDialogue != null)
            {
                nextDialogue.StartDialogue();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dante_Paraplegic")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
