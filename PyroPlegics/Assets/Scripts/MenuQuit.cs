using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    void Start()
    {
        // Get the Button component and add a listener to it
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(QuitGame);
        }
    }

    public void QuitGame()
    {
        // Log a message to console (useful for testing in the editor)
        Debug.Log("Game is quitting...");
        
        // Quit the application
        Application.Quit();
    }
}