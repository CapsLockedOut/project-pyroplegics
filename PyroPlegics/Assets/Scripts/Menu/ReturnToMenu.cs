using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMenu : MonoBehaviour
{
    public void ReturnButton(){
        SceneManager.LoadScene("MainMenu");
    }
}