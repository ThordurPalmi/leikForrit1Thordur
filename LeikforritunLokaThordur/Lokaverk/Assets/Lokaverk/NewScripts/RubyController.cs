using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    public float speed = 4;
    public float jumpForce = 5f;   // Hoppstyrkur leikmanns
    public int maxHealth = 5; // Hámarksheilsa leikmanns
    public float timeInvincible = 2.0f; // Tími þegar leikmaður er ósærður
    public ParticleSystem hitParticle; // Trefill sem sprettur þegar leikmaður verður fyrir skaða
    public GameObject projectilePrefab; // Forsenda fyrir skoti leikmanns
    public AudioClip hitSound; // Hljóð sem hljómar þegar leikmaður verður fyrir skaða
    public AudioClip shootingSound; // Hljóð sem hljómar þegar leikmaður skýtur
    public int health
    {
        get { return currentHealth; }
    }

    Rigidbody2D rigidbody2d;
    Vector2 currentInput;
    int currentHealth;
    float invincibleTimer;
    bool isInvincible;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    AudioSource audioSource;

    // Add a ground check
    public bool isGrounded;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Náum í Rigidbody2D komponentið
        invincibleTimer = -1.0f; // Byrjum með -1 á invincibleTimer
        currentHealth = maxHealth; // Setjum currentHealth sem hámarksheilsu
        animator = GetComponent<Animator>(); // Náum í Animator komponentið
        audioSource = GetComponent<AudioSource>(); // Náum í AudioSource komponentið
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime; // Minkum invincibleTimer með tímanum
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        float horizontal = Input.GetAxis("Horizontal"); // Sækjum horizontal input
        Vector2 move = new Vector2(horizontal, 0f); // Búum til hreyfingu í x-ás með inputinu

        if (!Mathf.Approximately(move.x, 0.0f))
        {
            lookDirection.Set(move.x, move.y); // Setjum lookDirection í réttu x-ás gildið
            lookDirection.Normalize(); // Normalizum lookDirection
        }

        currentInput = move; // Setjum currentInput sem move

        animator.SetFloat("Look X", lookDirection.x); // Setjum "Look X" gildið í lookDirection.x
        animator.SetFloat("Speed", move.magnitude); // Setjum "Speed" gildið í lengd hreyfingarinnar

        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(currentInput.x * speed, rigidbody2d.velocity.y); // Reiknum hraða leikmanns í hverri frame
        rigidbody2d.velocity = velocity; // Setjum nýja hraðann á Rigidbody2D komponentið
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            animator.SetTrigger("Hit"); // Spilum "Hit" trigger í Animator komponentinum til að sjá skaðatöfra
            audioSource.PlayOneShot(hitSound); // Spilum skaðahljóð

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity); // Búum til og sýnum trefil sem sprettur þegar leikmaður verður fyrir skaða
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // Uppfærum heilsu leikmanns

        if (currentHealth == 0)
            SceneManager.LoadScene("Death"); // Ef heilsan er 0, hleðjum inn "Death" senu
    }


    // =============== SKOT ========================
    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity); // Búum til nýtt skot á tilteknum stað

        Projectile projectile = projectileObject.GetComponent<Projectile>(); // Náum í Projectile komponentið á skotinu
        projectile.Launch(lookDirection, 300); // Skjótum skotinu í ákveðna átt og hraða

        animator.SetTrigger("Launch"); // Spilum "Launch" trigger í Animator komponentinum til að sjá skotið
        audioSource.PlayOneShot(shootingSound); // Spilum hljóð þegar leikmaður skýtur
    }

    // =============== HLJÓÐ ==========================

    // Gerir kleift að spila hljóð á hljóðkeldu leikmanns. Notað af Collectible
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip); // Spilum hljóð á hljóðkeldu
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Athugum hvort leikmaður sé á jörðinni
        }
    }

    void Jump()
    {
        rigidbody2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Skellum leikmanni upp í loftið
        isGrounded = false; // Leikmaður er ekki lengur á jörðinni
    }
}
