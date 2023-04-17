using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score; // N�verandi stig leikmannsins.
    public string sceneName; // Nafn � senu sem leikma�urinn fer til �egar hann n�r stigafj�lda �kve�inna marka.

    void Start()
    {
        _score = 0; // Byrjar me� stigafj�lda sem er n�ll.
        UpdateScoreText(); // Birtir stigin � skj�num.
    }

    void Update()
    {
        if (_score >= 180) // Ef stigafj�ldinn n�r �kve�num marka...
        {
            SceneManager.LoadScene(sceneName); // Hle�ur inn � senu sem var gefin upp ��ur.
            Cursor.lockState = CursorLockMode.None; // S�nir m�sarbendilinn aftur.
            Cursor.visible = true; // S�nir m�sarbendilinn aftur.
        }
    }

    void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score; // Birtir n�verandi stig � skj�num.
    }

    public void AddScore(int points)
    {
        _score += points; // B�tir vi� stigum eftir hversu miki� var n�� � marki.
        UpdateScoreText(); // Birtir n�ju stigin � skj�num.
    }

}
