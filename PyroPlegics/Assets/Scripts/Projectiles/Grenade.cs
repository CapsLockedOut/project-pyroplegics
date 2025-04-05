using UnityEngine;

public class Grenade : ExplosiveProjectile
{
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Grenade").Length > 3)
        {
            Destroy(gameObject);
            return;
        }
        GetComponent<Rigidbody>().useGravity = true;
        gameObject.tag = "Grenade";
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
            Explode(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
