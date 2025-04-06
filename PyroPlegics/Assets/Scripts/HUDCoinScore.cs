using UnityEngine;
using TMPro;

public class HUDCoinScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsCollectedText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // If not assigned in inspector, try to find it
        if (coinsCollectedText == null)
        {
            coinsCollectedText = GetComponent<TextMeshProUGUI>();
            
            if (coinsCollectedText == null)
            {
                Debug.LogError("TextMeshProUGUI component not found!");
                return;
            }
        }
        
        // Set initial display
        UpdateScore(0);
        
        // Subscribe to player score events if player score exists
        if (PlayerScore.Instance != null)
        {
            // Initialize with current score
            UpdateScore(PlayerScore.Instance.Score);
        }
    }

    private void OnEnable()
    {
        // Subscribe to score change events
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.OnScoreChanged += UpdateScore;
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from events
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.OnScoreChanged -= UpdateScore;
        }
    }

    private void UpdateScore(int newScore)
    {
        if (coinsCollectedText != null)
        {
            coinsCollectedText.text = newScore.ToString();
        }
    }
}