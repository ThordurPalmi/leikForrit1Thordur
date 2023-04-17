using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10;
    [SerializeField] private float _rotateSpeed = 90f;

    private Score _scoreboard;

    void Start()
    {
        _scoreboard = FindObjectOfType<Score>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Update()
    {
        transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);
    }

    void Collect()
    {
        _scoreboard.AddScore(_scoreValue);
        Destroy(gameObject);
    }
}
