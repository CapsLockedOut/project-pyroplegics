using UnityEngine;

public class WeaponDetection : MonoBehaviour
{
    public GameObject dialogueTemplate;
    public GameObject canva;
    public GameObject canvaInteract;
    public GameObject weapon;
    bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            canvaInteract.SetActive(true);
        }
        else {canvaInteract.SetActive(false);}
        
        
        // Check if the player is in range and presses the E key to start dialogue
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
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
            Destroy(weapon);
            canvaInteract.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dante_Paraplegic" || other.gameObject.name == "Player" || other.gameObject.name == "Dante_Paraplegic Variant")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
