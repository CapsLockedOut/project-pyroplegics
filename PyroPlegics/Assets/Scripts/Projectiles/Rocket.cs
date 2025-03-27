using UnityEngine;

public class Rocket : ExplosiveProjectile
{
    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}

