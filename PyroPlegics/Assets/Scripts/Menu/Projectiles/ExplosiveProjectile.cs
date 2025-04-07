using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    [Header("Explosion Settings")]
    public float explosionForce;         // Base explosion force
    public float explosionRadius;          // Radius within which objects are affected
    public float upwardModifier;           // Additional upward force for a stronger rocket jump
    public float additionalHorizontalForce; // Extra horizontal force to boost lateral movement

    public void Explode(bool dim)
    {
        Debug.Log(dim);
        Vector3 explosionPosition = transform.position;

        // Get all colliders within the explosion radius
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // Look for any Rigidbody in the colliders (for instance, the player's Rigidbody)
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && rb.gameObject.name != "Rocket(Clone)")
            {
                // float temp = additionalHorizontalForce;

                // Dampen previous velocity
                rb.linearVelocity = new Vector3(rb.linearVelocity.x*0.75f, 0, rb.linearVelocity.z*0.75f);

                // Apply explosion force to simulate a rocket jump effect
                // if (dim) {
                //     rb.AddExplosionForce(explosionForce*0.5f, explosionPosition, explosionRadius, upwardModifier, ForceMode.Impulse);
                //     additionalHorizontalForce = (explosionForce + additionalHorizontalForce)/2;
                // }
                // else
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
                // additionalHorizontalForce = temp;
            }
        }

        // Destroy the object after the explosion
        Destroy(gameObject);
    }
}
