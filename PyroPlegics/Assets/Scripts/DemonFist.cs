using UnityEngine;

public class DemonFist : MonoBehaviour
{
    public float force = 20f;

    private void OnTriggerEnter(Collider other)
    {
        Transform transform = GetComponent<Transform>();
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            rb.linearVelocity = transform.up * force;
        }
    }
}
