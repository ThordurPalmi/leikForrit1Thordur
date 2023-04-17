using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private int _scoreValue = 10;

    private float _currentHealth; // N�verandi l�f �vinar.
    private Transform _player; // Breyta sem heldur utan um sta�setningu leikmannsins.
    private Score _scoreboard; // Breyta sem heldur utan um stigat�fluna.

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform; // Finnum sta�setningu leikmannsins.
        _currentHealth = _maxHealth; // Setjum l�f �vinarins � h�marksl�f hans.
        _scoreboard = FindObjectOfType<Score>(); // Finnum stigat�fluna � leiknum.
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position); // Reiknum fjarl�g�ina milli leikmannsins og �vinarins.

        if (distanceToPlayer <= _range) // Ef leikma�urinn er innan vi� fjarl�g� �vinarins...
        {
            Vector3 direction = (_player.position - transform.position).normalized; // Finnum stefnu � leikmanni.
            transform.Translate(direction * _speed * Time.deltaTime); // F�rum �vininn � stefnu leikmannsins.
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>(); // Athugum hvort hluturinn sem �vinurinn rekst � s� skoti�.
        if (bullet != null)
        {
            float damage = bullet.Damage; // Finnum ska�ann sem skotinu valdi�.
            _currentHealth -= damage; // Dr�gum af l�finu �vinarins.
            Destroy(collision.gameObject); // Ey�um skotinu sem haf�i rekist � �vininn.

            if (_currentHealth <= 0f) // Ef �vinurinn deyr...
            {
                Die(); // Kallar � falli� sem s�r um a� drepa �vininn.
            }
        }
        else if (collision.gameObject.CompareTag("Player")) // Ef �vinurinn rekst � leikmanninn...
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage); // Kallar � fall � PlayerHealth kl�snum til a� taka ska�a.
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage; // Dr�gum af l�finu �vinarins.
        if (_currentHealth <= 0f) // Ef �vinurinn deyr...
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
