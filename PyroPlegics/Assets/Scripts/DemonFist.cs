using UnityEngine;

public class DemonFist : MonoBehaviour
{
    public float force = 20f;

    private void OnTriggerEnter(Collider other)
    {
        Transform rb = GetComponent<Transform>();
        Rigidbody otherRB = other.attachedRigidbody;
        Debug.Log(rb + "\n" + otherRB);

        if (otherRB != null)
        {
            otherRB.linearVelocity = rb.up * force;
        }
    }
}
