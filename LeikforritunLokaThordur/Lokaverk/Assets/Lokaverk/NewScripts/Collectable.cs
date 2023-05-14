using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 10; // hversu mörg stig

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ef samhluti er "Leikmaður"
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // Finnum ScoreManager hlutinn
            if (scoreManager != null) // Ef ScoreManager er til staðar
            {
                scoreManager.AddScore(scoreValue); // Bæta við stigunum í ScoreManager
            }

            Destroy(gameObject); // Eyða sjálfum safninu
        }
    }
}
