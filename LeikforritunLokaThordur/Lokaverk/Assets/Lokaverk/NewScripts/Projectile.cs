using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int damageAmount = 1; // Bætt við skert skaða magni

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Eyða skotinu þegar það nær fjarlægð af 1000.0f frá upphafspunktinum
        if (transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    // Kallað af leikmannsstjórnandahlutnum þegar það býr til nýtt skot til að skjóta það af stað.
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();

        // Ef hluturinn sem við snertum var óvinur, skertum hann og eyðum skotinu.
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);
        }

        Destroy(gameObject);
    }
}
