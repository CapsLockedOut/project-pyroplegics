using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    // The fireball prefab to instantiate.
    public GameObject fireballPrefab;
    // Where the fireball spawns. You can create an empty child GameObject and position it as needed.
    public Transform fireballSpawn;
    // The player's transform. You can assign this in the Inspector.
    public Transform player;

    [Header("Fireball Settings")]
    // Speed at which the fireball moves.
    public float fireballSpeed = 10f;
    // Delay between each launch.
    public float launchDelay = 2f;

    void Start()
    {
        // Start launching fireballs repeatedly after an initial delay.
        InvokeRepeating(nameof(LaunchFireball), launchDelay, launchDelay);
    }

    void LaunchFireball()
    {
        if (player == null || fireballPrefab == null || fireballSpawn == null)
        {
            Debug.LogWarning("Missing reference for player, fireballPrefab, or fireballSpawn");
            return;
        }

        // Instantiate the fireball prefab at the fireball spawn position with no rotation.
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawn.position, Quaternion.identity);

        // Calculate the direction from the spawn point to the player.
        Vector3 direction = (player.position - fireballSpawn.position).normalized;

        // Optionally, rotate the fireball to face the player.
        fireball.transform.rotation = Quaternion.LookRotation(direction);

        // Get the Rigidbody component and apply velocity.
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }
        else
        {
            Debug.LogWarning("The fireball prefab is missing a Rigidbody component.");
        }
    }
}
