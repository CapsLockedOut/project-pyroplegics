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
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.readyToDialgoue)
        {
            canva.SetActive(true);
            PlayerMovement.readyToDialgoue = true;
            NewDialgoue("Hi!");
            NewDialgoue("This is a test.");
            NewDialgoue("Goodbye World!");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialgoue(string text)
    {
        GameObject templateClone = Instantiate(dialogueTemplate, dialogueTemplate.transform);
        templateClone.transform.parent = canva.transform;
        templateClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerObject")
        {
            playerInRange = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
    
}
