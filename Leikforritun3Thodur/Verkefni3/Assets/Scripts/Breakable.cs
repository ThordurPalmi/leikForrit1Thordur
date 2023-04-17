using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10;

    private Score _scoreboard;// Breyta sem heldur utan um stigat�fluna.

    void Start()
    {
        _scoreboard = FindObjectOfType<Score>();// Finnum stigat�fluna � leiknum.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))// Ef hlutur rekst � skotmerki...
        {
            Break();// Kallar � falli� til a� brj�ta hlutinn.
        }
    }

    void Break()
    {
        _scoreboard.AddScore(_scoreValue); // B�tir stigum vi� stigat�flu.
        Destroy(gameObject); // Ey�ir hlutnum sem var brotinn.
    }

}
