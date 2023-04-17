using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    public float Damage { get { return _damage; } }// Public a�fer� sem s�r um a� skila breytunni sem heldur utan um ska�a.

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();// Athugum hvort annar hlutur sem vi� rekumst � s� �vinur.
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);// Kallar � a�fer� � Enemy kl�snum til a� taka ska�a.
            Destroy(gameObject);// Ey�ir skotinu sem haf�i rekist � �vininn.
        }
    }

}
