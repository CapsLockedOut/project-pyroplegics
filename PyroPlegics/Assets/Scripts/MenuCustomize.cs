using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCustomize: MonoBehaviour
{
    public void CustomizeButton(){
        SceneManager.LoadScene("CustomizeMenu");
    }
}