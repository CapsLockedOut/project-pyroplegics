using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string toScene;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dante is now on " + toScene);
            SceneManager.LoadScene(toScene);
        }
    }
}
