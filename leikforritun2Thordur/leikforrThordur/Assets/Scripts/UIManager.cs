using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI PointsText;

    private PlayerController _playerController;

    void Start()
    {
        // Find the player object and get its PlayerController component
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerController = playerObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        // Update the LivesText and PointsText based on the player's current lives and points
        int lives = _playerController.lives;
        int points = _playerController.points;
        LivesText.text = "Lives: " + lives.ToString();
        PointsText.text = "Points: " + points.ToString();
    }
}
