using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score;

    void Start()
    {
        _score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void AddScore(int points)
    {
        _score += points;
        UpdateScoreText();
    }
}
