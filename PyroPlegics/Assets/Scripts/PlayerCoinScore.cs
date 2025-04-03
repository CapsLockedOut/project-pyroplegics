using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
    }
}