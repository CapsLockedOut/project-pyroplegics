using UnityEngine;

public class NPCFakeDetection : MonoBehaviour
{
    public GameObject canvaInteract;
    bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            canvaInteract.SetActive(true);
        }
        else {canvaInteract.SetActive(false);}
        
        // Check if the player is in range and presses the E key to trigger the explosion
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // --- Destroy this object ---
            Destroy(GameObject.Find("fakeNPC"));

            // Disable interaction UI
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
