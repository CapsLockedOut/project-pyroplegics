using UnityEngine;
using System.Collections;

public class BlinkingPlatform : Platform
{
    [Header("Blink Settings")]
    [Tooltip("Time in seconds the platform stays visible")]
    public float timeVisible = 2f;
    
    [Tooltip("Time in seconds the platform stays invisible")]
    public float timeInvisible = 1f;

    [Header("Components")]
    [SerializeField] private Collider platformCollider;
    [SerializeField] private Renderer platformRenderer;

    public override void Start()
    {
        // Auto-get components if not assigned
        if (platformCollider == null) platformCollider = GetComponent<Collider>();
        if (platformRenderer == null) platformRenderer = GetComponent<Renderer>();
        
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Platform visible
            SetPlatformActive(true);
            yield return new WaitForSeconds(timeVisible);
            
            // Platform hidden
            SetPlatformActive(false);
            yield return new WaitForSeconds(timeInvisible);
        }
    }

    private void SetPlatformActive(bool state)
    {
        platformCollider.enabled = state;
        platformRenderer.enabled = state;
    }

    // Optional: Validate input values in editor
    private void OnValidate()
    {
        timeVisible = Mathf.Max(0.1f, timeVisible);
        timeInvisible = Mathf.Max(0.1f, timeInvisible);
    }
}
