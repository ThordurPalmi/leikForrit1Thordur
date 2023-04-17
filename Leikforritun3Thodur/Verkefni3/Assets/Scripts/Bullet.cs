using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    public float Damage { get { return _damage; } }// Public aðferð sem sér um að skila breytunni sem heldur utan um skaða.

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();// Athugum hvort annar hlutur sem við rekumst á sé óvinur.
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);// Kallar á aðferð í Enemy klösnum til að taka skaða.
            Destroy(gameObject);// Eyðir skotinu sem hafði rekist á óvininn.
        }
    }

}
