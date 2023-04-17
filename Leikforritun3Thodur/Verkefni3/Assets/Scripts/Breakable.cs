using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10;

    private Score _scoreboard;// Breyta sem heldur utan um stigatöfluna.

    void Start()
    {
        _scoreboard = FindObjectOfType<Score>();// Finnum stigatöfluna í leiknum.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))// Ef hlutur rekst á skotmerki...
        {
            Break();// Kallar á fallið til að brjóta hlutinn.
        }
    }

    void Break()
    {
        _scoreboard.AddScore(_scoreValue); // Bætir stigum við stigatöflu.
        Destroy(gameObject); // Eyðir hlutnum sem var brotinn.
    }

}
