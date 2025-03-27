using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    private int index = 1;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.childCount > 0)
        {
            if (PlayerMovement.readyToDialgoue)
            {
                transform.GetChild(index).gameObject.SetActive(false);
                index += 1;
                if (index < transform.childCount)
                {
                    transform.GetChild(index).gameObject.SetActive(true);
                }
                else
                {
                    index = 1;
                    PlayerMovement.readyToDialgoue = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
