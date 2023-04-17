using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10;
    [SerializeField] private float _rotateSpeed = 90f;

    private Score _scoreboard;// Breyta sem heldur utan um stigat�fluna.

    void Start()
    {
        _scoreboard = FindObjectOfType<Score>();// Finnum stigat�fluna � leiknum.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))// Ef leikma�ur rekst � hlutinn...
        {
            Collect();// Kallar � falli� til a� safna hlutnum.
        }
    }

    void Update()
    {
        transform.Rotate(0f, _rotateSpeed * Time.deltaTime, 0f);// Sn�r hlutnum � kringum sj�lfan sig.
    }

    void Collect()
    {
        _scoreboard.AddScore(_scoreValue);// B�tir stigum vi� stigat�flu.
        Destroy(gameObject);// Ey�ir hlutnum sem var safna�.
    }
}
