using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score; // Núverandi stig leikmannsins.

    void Start()
    {
        _score = 0; // Byrjar með stigafjölda sem er núll.
        UpdateScoreText(); // Birtir stigin á skjánum.
    }

    void Update()
    {
        if (_score >= 180) // Ef stigafjöldinn nær ákveðnum marka...
        {
            Cursor.lockState = CursorLockMode.None; // Sýnir músarbendilinn aftur.
            Cursor.visible = true; // Sýnir músarbendilinn aftur.
        }
    }

    void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score; // Birtir núverandi stig á skjánum.
    }

    public void AddScore(int points)
    {
        _score += points; // Bætir við stigum eftir hversu mikið var náð á marki.
        UpdateScoreText(); // Birtir nýju stigin á skjánum.
    }
}