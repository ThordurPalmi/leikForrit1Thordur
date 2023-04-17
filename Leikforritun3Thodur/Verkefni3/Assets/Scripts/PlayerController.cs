using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 5f;
    [SerializeField] private float maxLookUpAngle = 90f;
    [SerializeField] private float maxLookDownAngle = -90f;

    private float _xRotation = 0f; // Breyta sem heldur utan um snúning á X-ás.
    private float _yRotation = 0f; // Breyta sem heldur utan um snúning á Y-ás.

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Felum músarbendilinn.
        Cursor.visible = false; // Felum músarbendilinn.
    }

    void Update()
    {
        // Hreyfing
        float horizontal = Input.GetAxisRaw("Horizontal"); // Tekur inn hreyfingar á lárétta ásnum.
        float vertical = Input.GetAxisRaw("Vertical"); // Tekur inn hreyfingar á lóðréttum ásnum.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Býr til stefnuvektor fyrir hreyfinguna.
        transform.Translate(direction * moveSpeed * Time.deltaTime); // Hreyfir leikmanninn í rétta átt.

        // Snúningur
        float mouseX = Input.GetAxisRaw("Mouse X") * lookSpeed * Time.deltaTime; // Tekur inn snúning á X-ás með músinni.
        float mouseY = Input.GetAxisRaw("Mouse Y") * lookSpeed * Time.deltaTime; // Tekur inn snúning á Y-ás með músinni.
        _xRotation += mouseY; // Bætir við snúningnum á X-ás.
        _xRotation = Mathf.Clamp(_xRotation, maxLookDownAngle, maxLookUpAngle); // Kallar á Mathf.Clamp() til að takmarka snúninginn á milli lágmarks og hámarks gilda.
        _yRotation += mouseX; // Bætir við snúningnum á Y-ás.
        transform.localRotation = Quaternion.Euler(-_xRotation, _yRotation, 0f); // Snýr leikmanninum í rétta átt með nýju snúningi.
    }
}
