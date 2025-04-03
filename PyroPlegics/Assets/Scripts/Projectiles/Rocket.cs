using UnityEngine;

public class Rocket : ExplosiveProjectile
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.name != "Player")
            Explode();
    }
}

