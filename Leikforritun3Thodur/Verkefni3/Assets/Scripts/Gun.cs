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
        if (Input.GetButtonDown("Fire1")) // Ef leikma�urinn �tir � m�sarb�tinn...
        {
            Shoot(); // Kallar � falli� sem l�tur byssuna skj�ta.
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation); // B�r til n�tt skot af byssunni.
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // Finnur Rigidbody hlutinn � skotinu.
        bulletRigidbody.AddForce(_muzzle.forward * _bulletSpeed, ForceMode.Impulse); // L�tur skotinu hreyfast � stefnu hlj��munnar byssunnar.
        Destroy(bullet, 5f); // Ey�ir skotinu eftir 5 sek�ndur.
    }
}
