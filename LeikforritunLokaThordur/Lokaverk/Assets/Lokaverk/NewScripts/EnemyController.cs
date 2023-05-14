using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 5; // H�marksheilsa �vinarins
    public float moveSpeed = 2f; // Hra�i �vinarins
    public float intervalDuration = 2f; // T�malengd hvers hreyfingarbils
    private bool movingRight = true; // Flag til a� �kve�a �tt hreyfingar �vinarins
    private float intervalTimer; // Teljari til a� fylgja me� n�verandi bili
    private int currentHealth; // N�verandi heilsa �vinarins
    public int scoreValue = 10; // Stig sem eru gefin fyrir a� drepa �ennan �vin
    private ScoreManager scoreManager; // Vi�v�run um ScoreManager skriftuna
    private void Start()
    {
        currentHealth = maxHealth; // Setjum n�verandi heilsu sem h�marksheilsu
        scoreManager = FindObjectOfType<ScoreManager>(); // Finnum ScoreManager hlutinn
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Minkum n�verandi heilsu um gefi� magn

        // Athugum hvort heilsa �vinarins s� or�in 0 e�a minni
        if (currentHealth <= 0)
        {
            scoreManager.AddScore(scoreValue); // B�tum vi� stigum � ScoreManager
            Destroy(gameObject); // Ey�um �vininum
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player")) // Ef annar hlutur er ekki null og er "Leikma�ur"
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
                TakeDamage(projectile.damageAmount); // Minkum heilsu �vinar um skert skade
                Destroy(other.gameObject); // Ey�um skotinu
            }
        }
    }

    private void Update()
    {
        // Athugum hvort s� kominn t�mi til a� skipta um �tt
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= intervalDuration)
        {
            intervalTimer = 0f;
            movingRight = !movingRight;
        }

        // Hreyfum �vininn eftir n�verandi �tt
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-5f, 5f, 1f); // Andlit � r�ttu �tt, til h�gri
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(5f, 5f, 1f); // Andlit � r�ttu �tt, til vinstri
        }
    }
}
