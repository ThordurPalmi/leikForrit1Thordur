using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score; // Núverandi stig leikmannsins.
    public string sceneName; // Nafn á senu sem leikmaðurinn fer til þegar hann nær stigafjölda ákveðinna marka.

    void Start()
    {
        _score = 0; // Byrjar með stigafjölda sem er núll.
        UpdateScoreText(); // Birtir stigin á skjánum.
    }

    void Update()
    {
        if (_score >= 180) // Ef stigafjöldinn nær ákveðnum marka...
        {
            SceneManager.LoadScene(sceneName); // Hleður inn í senu sem var gefin upp áður.
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
