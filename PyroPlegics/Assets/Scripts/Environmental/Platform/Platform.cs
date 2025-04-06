using UnityEngine;

public class Platform : MonoBehaviour
{
    public virtual void Start()
    {
        this.gameObject.tag = "NoJump";
    }
}