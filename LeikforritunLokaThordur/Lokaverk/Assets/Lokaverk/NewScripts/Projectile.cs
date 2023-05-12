using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int damageAmount = 1; // Add a damage amount field

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Destroy the projectile when it reaches a distance of 1000.0f from the origin
        if (transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    // Called by the player controller after it instantiates a new projectile to launch it.
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();

        // If the object we touched was an enemy, damage it and destroy the projectile.
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);
        }

        Destroy(gameObject);
    }
}
