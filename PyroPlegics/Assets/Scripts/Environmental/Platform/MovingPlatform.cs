using UnityEngine;

public class MovingPlatform : Platform
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;

    public override void Start()
    {
        base.Start();
        target = pointB.position; // Start by moving towards pointB
    }

    void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the platform has reached the target
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            // Switch targets (A ↔ B)
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }
}
