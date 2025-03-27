using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    private int index = 0;
    private int totalDialogueCount;
    private bool isDialogueComplete = false;
    
    // This method is called when dialogue starts
    public void StartDialogue()
    {
        index = 0; // Start from 0, so we can show the first dialogue
        isDialogueComplete = false;
        totalDialogueCount = transform.childCount;

        // Check if there are any child dialogues
        if (totalDialogueCount > 0)
        {
            // Show the first dialogue
            transform.GetChild(index).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No dialogue children found in the canvas.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player clicks to advance the dialogue
        if (Input.GetMouseButtonDown(0) && !isDialogueComplete && transform.childCount > 0)
        {
            // Hide current dialogue
            transform.GetChild(index).gameObject.SetActive(false);

            // Move to the next dialogue
            index++;

            // Ensure we are within the bounds of the available dialogue children
            if (index < transform.childCount)
            {
                transform.GetChild(index).gameObject.SetActive(true);
            }
            else
            {
                // If no more dialogues, reset and end the dialogue
                EndDialogue();
            }
        }
    }

    // Ends the dialogue and resets the state
    private void EndDialogue()
    {
        index = 0; // Reset the index
        PlayerMovement.readyToDialgoue = false; // Allow player movement again
        gameObject.SetActive(false); // Disable the dialogue UI
        isDialogueComplete = true;
    }
}
