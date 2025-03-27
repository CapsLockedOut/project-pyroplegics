using UnityEngine;

public class MacGuffin : MonoBehaviour
{
    // Number of times the object has been hit
    private int hitCount = 0;
    
    // Number of hits required to destroy the parent object
    public int requiredHits = 3;

    // This function is called when the collider attached to this GameObject collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Rocket"
        if (collision.gameObject.CompareTag("Rocket"))
        {
            hitCount++;

            // If the number of hits is equal to or exceeds the required hits
            if (hitCount >= requiredHits)
            {
                // Destroy the parent GameObject
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }
                else
                {
                    // If there's no parent, destroy this object
                    Destroy(gameObject);
                }
            }
        }
    }
}