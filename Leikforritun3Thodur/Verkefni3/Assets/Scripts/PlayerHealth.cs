using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;
    public string sceneName;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log("Player health: " + _currentHealth);

        if (_currentHealth <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(sceneName);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
