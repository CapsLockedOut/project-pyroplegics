using System;
using UnityEngine;

public class BreakablePlatform : Platform
{
    public int platformHealth = 5;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Rocket Projectile(Clone)" || other.gameObject.name == "QuadRocket(Clone)")
        {
            platformHealth--;
            if (platformHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
