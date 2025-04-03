using System;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public int platformHealth = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Rocket Projectile(Clone)")
        {
            platformHealth--;
            if (platformHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
