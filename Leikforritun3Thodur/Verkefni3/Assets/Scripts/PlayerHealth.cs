using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth; // Núverandi líf leikmannsins.
    public string sceneName; // Nafn á senu sem leikmaðurinn fer til þegar hann deyr.

    public float CurrentHealth { get { return _currentHealth; } } // Public aðferð sem skilar núverandi lífi leikmannsins.
    public float MaxHealth { get { return _maxHealth; } } // Public aðferð sem skilar hámarks lífi leikmannsins.

    void Start()
    {
        _currentHealth = _maxHealth; // Setur líf leikmannsins sem hámarks líf.
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage; // Drögum af lífinu leikmannsins eftir hversu mikið hann varð fyrir skaða.
        Debug.Log("Player health: " + _currentHealth); // Skrifar líf leikmannsins í console.

        if (_currentHealth <= 0f) // Ef lífið er orðið minna en eða jafnt og núll...
        {
            Die(); // Kallar á fallið sem lætur leikmanninn deyja.
        }
    }

    void Die()
    {
        SceneManager.LoadScene(sceneName); // Hleður inn í senu sem var gefin upp áður.
        Cursor.lockState = CursorLockMode.None; // Sýnir músarbendilinn aftur.
        Cursor.visible = true; // Sýnir músarbendilinn aftur.
    }

}
