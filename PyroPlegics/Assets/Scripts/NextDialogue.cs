using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    private int index = 2;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if (PlayerMovement.readyToDialgoue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if (transform.childCount == index)
                {
                    index = 2;
                    PlayerMovement.readyToDialgoue = false;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
