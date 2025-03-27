using UnityEngine;
using UnityEngine.InputSystem; // Import the new Input System

// Attach this to your weapon (child of the camera)
public class BulletShooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float bulletSpeed;          // Speed at which the bullet will travel
    public float fireInterval;
    public GameObject bulletPrefab;          // The bullet prefab to instantiate

    [Header("Fire Point")]
    public Transform firePoint;              // The transform from which the bullet will be fired

    void Update()
    {
        // Check for left mouse button press using the new Input System
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    // Method to handle shooting
    void Shoot()
    {
        // Instantiate the bullet prefab at the fire point's position and rotation
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Try to get the Rigidbody component from the instantiated bullet
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // For fast-moving objects, set continuous collision detection
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            // Set the velocity of the bullet in the forward direction of the fire point
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Bullet prefab is missing a Rigidbody component.");
        }
    }
}
