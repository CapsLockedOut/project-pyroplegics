using UnityEngine;
using System;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    
    // Event that will be triggered when the score changes
    public event Action<int> OnScoreChanged;
    
    private int _score;

    // Property to get the current score
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            // Notify listeners that the score has changed
            OnScoreChanged?.Invoke(_score);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        _score += amount;
        Debug.Log("Score: " + _score);
        
        // Notify listeners that the score has changed
        OnScoreChanged?.Invoke(_score);
    }
}