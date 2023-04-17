using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth; // N�verandi l�f leikmannsins.
    public string sceneName; // Nafn � senu sem leikma�urinn fer til �egar hann deyr.

    public float CurrentHealth { get { return _currentHealth; } } // Public a�fer� sem skilar n�verandi l�fi leikmannsins.
    public float MaxHealth { get { return _maxHealth; } } // Public a�fer� sem skilar h�marks l�fi leikmannsins.

    void Start()
    {
        _currentHealth = _maxHealth; // Setur l�f leikmannsins sem h�marks l�f.
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage; // Dr�gum af l�finu leikmannsins eftir hversu miki� hann var� fyrir ska�a.
        Debug.Log("Player health: " + _currentHealth); // Skrifar l�f leikmannsins � console.

        if (_currentHealth <= 0f) // Ef l�fi� er or�i� minna en e�a jafnt og n�ll...
        {
            Die(); // Kallar � falli� sem l�tur leikmanninn deyja.
        }
    }

    void Die()
    {
        SceneManager.LoadScene(sceneName); // Hle�ur inn � senu sem var gefin upp ��ur.
        Cursor.lockState = CursorLockMode.None; // S�nir m�sarbendilinn aftur.
        Cursor.visible = true; // S�nir m�sarbendilinn aftur.
    }

}
