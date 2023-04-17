using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10;

    private Score _scoreboard;

    void Start()
    {
        _scoreboard = FindObjectOfType<Score>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Break();
        }
    }

    void Break()
    {
        _scoreboard.AddScore(_scoreValue);
        Destroy(gameObject);
    }

}
