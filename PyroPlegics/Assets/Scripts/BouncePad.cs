using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceMultiplier = 1.2f;
    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        rb = other.attachedRigidbody;
        if (rb != null)
        {
            // Check if the object is moving downward before bouncing
            if (rb.linearVelocity.y < 0)
            {
                // Reverse the velocity and apply a multiplier
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, -rb.linearVelocity.y * bounceMultiplier, rb.linearVelocity.z);
            }
        }
    }
}
