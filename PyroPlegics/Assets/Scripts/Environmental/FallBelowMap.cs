using System;
using UnityEngine;

public class FallBelowMap : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float fallThreshold = -5.0f; // Define the threshold value

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerRigidbody == null)
        {
            playerRigidbody = FindFirstObjectByType<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody.transform.position.y < fallThreshold)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        playerRigidbody.position = new Vector3(0, 10, 0);
        playerRigidbody.linearVelocity = Vector3.zero; // Reset velocity to prevent continued falling
    }
}