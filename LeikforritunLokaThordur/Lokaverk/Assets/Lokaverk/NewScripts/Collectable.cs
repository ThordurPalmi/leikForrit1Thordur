using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 10; // hversu m�rg stig

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ef samhluti er "Leikma�ur"
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // Finnum ScoreManager hlutinn
            if (scoreManager != null) // Ef ScoreManager er til sta�ar
            {
                scoreManager.AddScore(scoreValue); // B�ta vi� stigunum � ScoreManager
            }

            Destroy(gameObject); // Ey�a sj�lfum safninu
        }
    }
}
