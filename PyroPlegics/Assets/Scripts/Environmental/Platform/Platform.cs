using UnityEngine;

public class Platform : MonoBehaviour
{
    public virtual void Start()
    {
        GetComponent<GameObject>().tag = "NoJump";
    }
}
