using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float moveSpeed = 2f; // Speed at which the enemy moves
    public float intervalDuration = 2f; // Duration of each movement interval
    private bool movingRight = true; // Flag to determine the enemy's movement direction
    private float intervalTimer; // Timer to track the current interval
    private int currentHealth; // Enemy's current health
    public int scoreValue = 10; // Score value awarded for killing this enemy
    private ScoreManager scoreManager; // Reference to the ScoreManager script



    private void Start()
    {
        currentHealth = maxHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Check if the enemy's health reaches 0 or below
        if (currentHealth <= 0)
        {
            scoreManager.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            RubyController ruby = other.GetComponent<RubyController>();
            if (ruby != null)
            {
                ruby.ChangeHealth(-1); // Decrease player's health by 1
            }
        }
        else if (other != null && other.CompareTag("PlayerProjectile"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damageAmount);
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        // Check if it's time to change direction
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= intervalDuration)
        {
            intervalTimer = 0f;
            movingRight = !movingRight;
        }

        // Move the enemy based on the current direction
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-5f, 5f, 1f); // Face right
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(5f, 5f, 1f); // Face left
        }
    }
}
