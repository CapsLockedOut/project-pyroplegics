using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string toScene;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Dante_Paraplegic" || other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(toScene);
        }
    }
}
