using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score;
    public string sceneName;

    void Start()
    {
        _score = 0;
        UpdateScoreText();
    }
    void Update()
    {
        if (_score >= 280)
        {
            SceneManager.LoadScene(sceneName);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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
