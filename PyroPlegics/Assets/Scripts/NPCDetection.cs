using UnityEngine;

public class NPCDetection : MonoBehaviour
{
    bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            print("Player is in the range");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && other.CompareTag("NPC"))
        {
            playerInRange = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
    
}
