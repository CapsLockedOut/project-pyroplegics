using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MacGuffin : MonoBehaviour
{
    // Number of times the object has been hit
    private int hitCount = 0;
    
    // Number of hits required to destroy the parent object
    public int requiredHits = 3;

    // How strong the knockback is
    public float knockbackForce = 10f;

    // Rotation settings
    public Vector3 rotationAxis = Vector3.up;
    public TextMeshProUGUI hitsText;
    public float rotationSpeed = 90f; // degrees per second

    private void Update()
    {
        // Rotate continuously while alive
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.Self);
    }
    if (hitCount >= requiredHits)
{
    Debug.Log("MacGuffin destroyed! Loading next scene...");

    // Destroy the object
    if (transform.parent != null)
        Destroy(transform.parent.gameObject);
    else
        Destroy(gameObject);

    // Load another scene (replace "NextSceneName" with your actual scene name)
    SceneManager.LoadScene("WinMenu");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 1) Count this as a hit
        hitCount++;
        
        // 2) Print "hit"
        Debug.Log("hit");

        // 3) Knock the other object away, if it has a Rigidbody
        Rigidbody otherRb = collision.rigidbody;
        if (otherRb != null)
        {
            Vector3 dir = (collision.transform.position - transform.position).normalized;
            otherRb.AddForce(dir * knockbackForce, ForceMode.Impulse);
        }

        // 4) If we've reached the threshold, destroy
        if (hitCount >= requiredHits)
        {
            if (transform.parent != null)
                Destroy(transform.parent.gameObject);
            else
                Destroy(gameObject);
        }
    void UpdateHUD()
        {
            if (hitsText != null)
            {
            int remaining = Mathf.Max(0, requiredHits - hitCount);
            hitsText.text = remaining > 0 ? $"{remaining} Hit(s) Remaining" : "Object Destroyed!";
            }
        }
    }
}