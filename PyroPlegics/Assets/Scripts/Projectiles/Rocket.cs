using UnityEngine;

public class Rocket : ExplosiveProjectile
{
    private Rigidbody rb;
    private bool alreadyDeonated;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        alreadyDeonated = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(alreadyDeonated)
            return;

        if(collision.gameObject.tag == "NoExplosion") {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.name != "Dante_PyroPlegic" && collision.gameObject.name != "Dante_PyroPlegic Variant") {
            Debug.Log("Collided with: " + collision.gameObject.name);
            alreadyDeonated = true;

            if (collision.gameObject.tag == "DimExplosion")
                Explode(true);
            else
                Explode(false);
        }
    }
}

