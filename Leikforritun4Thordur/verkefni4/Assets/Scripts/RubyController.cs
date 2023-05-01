using System;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 4;
    
   
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    
    
    public AudioClip hitSound;
    
    
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
    
    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();
                
        
        invincibleTimer = -1.0f;
        currentHealth = maxHealth;
        
        
        animator = GetComponent<Animator>();
        
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        currentInput = move;


        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        position = position + currentInput * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hitSound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth == 0)
            Respawn();
    }


    void Respawn()
    {
        ChangeHealth(maxHealth);
        transform.position = respawnPosition.position;
    }
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
