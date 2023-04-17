using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Ef leikmaðurinn ýtir á músarbútinn...
        {
            Shoot(); // Kallar á fallið sem lætur byssuna skjóta.
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation); // Býr til nýtt skot af byssunni.
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // Finnur Rigidbody hlutinn í skotinu.
        bulletRigidbody.AddForce(_muzzle.forward * _bulletSpeed, ForceMode.Impulse); // Lætur skotinu hreyfast í stefnu hljóðmunnar byssunnar.
        Destroy(bullet, 5f); // Eyðir skotinu eftir 5 sekúndur.
    }
}
