using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Explosion Settings")]
    public float explosionForce = 500f;         // Base explosion force
    public float explosionRadius = 5f;          // Radius within which objects are affected
    public float upwardModifier = 2f;           // Additional upward force for a stronger rocket jump
    public float additionalHorizontalForce = 200f; // Extra horizontal force to boost lateral movement

    void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionPosition = transform.position;

        // Get all colliders within the explosion radius
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // Look for any Rigidbody in the colliders (for instance, the player's Rigidbody)
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && rb.gameObject.name != "Rocket(Clone)")
            {
                // Dampen previous velocity
                rb.linearVelocity = new Vector3(rb.linearVelocity.x*0.75f, 0, rb.linearVelocity.z*0.75f);

                // Apply explosion force to simulate a rocket jump effect
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardModifier, ForceMode.Impulse);
                
                // Calculate horizontal direction
                Vector3 horizontalDirection = rb.position - explosionPosition;
                horizontalDirection.y = 0f;  // Remove vertical component

                if (horizontalDirection != Vector3.zero)
                {
                    horizontalDirection.Normalize();
                    // Apply additional horizontal force to boost lateral movement
                    rb.AddForce(horizontalDirection * additionalHorizontalForce, ForceMode.Impulse);
                }
            }
        }

        // Destroy the object after the explosion
        Destroy(gameObject);
    }
}
