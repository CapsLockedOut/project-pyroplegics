using System;
using UnityEngine;

public class FallBelowMap : MonoBehaviour
{
    public CharacterController character;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        if (character == null)
        {
            character = FindObjectsByType<CharacterController>();
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            character.enabled = false;
            character.transform.position = new Vector3(0, 10, 0);
            character.enabled = true;
        }
    }
}
