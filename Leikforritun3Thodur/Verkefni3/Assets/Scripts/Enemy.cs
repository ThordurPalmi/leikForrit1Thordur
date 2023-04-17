using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private int _scoreValue = 10;

    private float _currentHealth; // Núverandi líf óvinar.
    private Transform _player; // Breyta sem heldur utan um staðsetningu leikmannsins.
    private Score _scoreboard; // Breyta sem heldur utan um stigatöfluna.

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform; // Finnum staðsetningu leikmannsins.
        _currentHealth = _maxHealth; // Setjum líf óvinarins í hámarkslíf hans.
        _scoreboard = FindObjectOfType<Score>(); // Finnum stigatöfluna í leiknum.
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position); // Reiknum fjarlægðina milli leikmannsins og óvinarins.

        if (distanceToPlayer <= _range) // Ef leikmaðurinn er innan við fjarlægð óvinarins...
        {
            Vector3 direction = (_player.position - transform.position).normalized; // Finnum stefnu á leikmanni.
            transform.Translate(direction * _speed * Time.deltaTime); // Færum óvininn í stefnu leikmannsins.
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>(); // Athugum hvort hluturinn sem óvinurinn rekst á sé skotið.
        if (bullet != null)
        {
            float damage = bullet.Damage; // Finnum skaðann sem skotinu valdið.
            _currentHealth -= damage; // Drögum af lífinu óvinarins.
            Destroy(collision.gameObject); // Eyðum skotinu sem hafði rekist á óvininn.

            if (_currentHealth <= 0f) // Ef óvinurinn deyr...
            {
                Die(); // Kallar á fallið sem sér um að drepa óvininn.
            }
        }
        else if (collision.gameObject.CompareTag("Player")) // Ef óvinurinn rekst á leikmanninn...
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage); // Kallar á fall í PlayerHealth klösnum til að taka skaða.
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage; // Drögum af lífinu óvinarins.
        if (_currentHealth <= 0f) // Ef óvinurinn deyr...
        {
            Die();
        }
    }

    void Die()
    {
        _scoreboard.AddScore(_scoreValue);
        Destroy(gameObject);
    }
}
