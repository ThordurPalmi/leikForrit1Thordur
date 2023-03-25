/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{ 

    private int lives;
    private int points;

    public static string sceneName = "MainMenu";

    private GameManager gameManager;

    void Start()
    {
        // Set the initial text of the lives and points UI elements
        Text livesText = GameObject.Find("LivesText").GetComponent<Text>();
        Text pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        livesText.text = "Lives: " + lives.ToString();
        pointsText.text = "Points: " + points.ToString();
    }
    public void UpdateLives(int value)
    {
        // Update the lives value
        lives += value;

        // Update the lives UI
        Text livesText = GameObject.Find("LivesText").GetComponent<Text>();
        livesText.text = "Lives: " + lives.ToString();
    }
    public void UpdatePoints(int value)
    {
        // Update the points value
        points += value;

        // Update the points UI
        Text pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        pointsText.text = "Points: " + points.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            if (lives <= 0)
            {
                // Game over
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                // Respawn the player
                transform.position = new Vector3(0f, 0.5f, 0f);

                // Update the lives UI
                GameObject canvasObject = GameObject.Find("Canvas");
                UIScript uiScript = canvasObject;
            }
        }
    }
}*/
