using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 5; // Hámarksheilsa óvinarins
    public float moveSpeed = 2f; // Hraði óvinarins
    public float intervalDuration = 2f; // Tímalengd hvers hreyfingarbils
    private bool movingRight = true; // Flag til að ákveða átt hreyfingar óvinarins
    private float intervalTimer; // Teljari til að fylgja með núverandi bili
    private int currentHealth; // Núverandi heilsa óvinarins
    public int scoreValue = 10; // Stig sem eru gefin fyrir að drepa þennan óvin
    private ScoreManager scoreManager; // Viðvörun um ScoreManager skriftuna
    private void Start()
    {
        currentHealth = maxHealth; // Setjum núverandi heilsu sem hámarksheilsu
        scoreManager = FindObjectOfType<ScoreManager>(); // Finnum ScoreManager hlutinn
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Minkum núverandi heilsu um gefið magn

        // Athugum hvort heilsa óvinarins sé orðin 0 eða minni
        if (currentHealth <= 0)
        {
            scoreManager.AddScore(scoreValue); // Bætum við stigum í ScoreManager
            Destroy(gameObject); // Eyðum óvininum
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player")) // Ef annar hlutur er ekki null og er "Leikmaður"
        {
            RubyController ruby = other.GetComponent<RubyController>(); // Finnum RubyController hlutinn
            if (ruby != null)
            {
                ruby.ChangeHealth(-1); // Minkum heilsu leikmanns um 1
            }
        }
        else if (other != null && other.CompareTag("PlayerProjectile")) // Ef annar hlutur er ekki null og er "PlayerProjectile"
        {
            Projectile projectile = other.GetComponent<Projectile>(); // Finnum Projectile hlutinn
            if (projectile != null)
            {
                TakeDamage(projectile.damageAmount); // Minkum heilsu óvinar um skert skade
                Destroy(other.gameObject); // Eyðum skotinu
            }
        }
    }

    private void Update()
    {
        // Athugum hvort sé kominn tími til að skipta um átt
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= intervalDuration)
        {
            intervalTimer = 0f;
            movingRight = !movingRight;
        }

        // Hreyfum óvininn eftir núverandi átt
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-5f, 5f, 1f); // Andlit í réttu átt, til hægri
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(5f, 5f, 1f); // Andlit í réttu átt, til vinstri
        }
    }
}
