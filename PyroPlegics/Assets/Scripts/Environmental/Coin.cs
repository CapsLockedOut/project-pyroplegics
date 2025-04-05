using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle coin pickup logic here
            // For example, increase the player's score
            PlayerScore.Instance.AddScore(1);

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}