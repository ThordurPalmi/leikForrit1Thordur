using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 10f;

    private float _currentHealth;
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer <= _range)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            float damage = bullet.Damage;
            _currentHealth -= damage;
            Destroy(collision.gameObject);

            if (_currentHealth <= 0f)
            {
                Die();
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
