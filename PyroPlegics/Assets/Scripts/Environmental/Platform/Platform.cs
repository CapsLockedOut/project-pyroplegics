using UnityEngine;

public class Platform : MonoBehaviour
{
    public virtual void Start()
    {
        gameObject.tag = "NoJump";
    }
}