using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPlay : MonoBehaviour
{
    public void PlayButton(){
        SceneManager.LoadScene("Level1");
    }
}