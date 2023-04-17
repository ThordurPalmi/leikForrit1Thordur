using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10;
    [SerializeField] private float _rotateSpeed = 90f;

    private Score _scoreboard;// Breyta sem heldur utan um stigatöfluna.

    void Start()
    {
        _scoreboard = FindObjectOfType<Score>();// Finnum stigatöfluna í leiknum.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))// Ef leikmaður rekst á hlutinn...
        {
            Collect();// Kallar á fallið til að safna hlutnum.
        }
    }

    void Update()
    {
        transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);// Snýr hlutnum á kringum sjálfan sig.
    }

    void Collect()
    {
        _scoreboard.AddScore(_scoreValue);// Bætir stigum við stigatöflu.
        Destroy(gameObject);// Eyðir hlutnum sem var safnað.
    }
}
