using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _healthBar;

    void Start()
    {
        // Get a reference to the health bar image component
        _healthBar = GetComponent<Image>();
    }

    void Update()
    {
        // Update the health bar fill amount based on the player's current health
        _healthBar.fillAmount = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
    }
}
