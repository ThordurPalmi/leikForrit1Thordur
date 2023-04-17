using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 5f;
    [SerializeField] private float maxLookUpAngle = 90f;
    [SerializeField] private float maxLookDownAngle = -90f;

    private float _xRotation = 0f; // Breyta sem heldur utan um sn�ning � X-�s.
    private float _yRotation = 0f; // Breyta sem heldur utan um sn�ning � Y-�s.

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Felum m�sarbendilinn.
        Cursor.visible = false; // Felum m�sarbendilinn.
    }

    void Update()
    {
        // Hreyfing
        float horizontal = Input.GetAxisRaw("Horizontal"); // Tekur inn hreyfingar � l�r�tta �snum.
        float vertical = Input.GetAxisRaw("Vertical"); // Tekur inn hreyfingar � l��r�ttum �snum.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // B�r til stefnuvektor fyrir hreyfinguna.
        transform.Translate(direction * moveSpeed * Time.deltaTime); // Hreyfir leikmanninn � r�tta �tt.

        // Sn�ningur
        float mouseX = Input.GetAxisRaw("Mouse X") * lookSpeed * Time.deltaTime; // Tekur inn sn�ning � X-�s me� m�sinni.
        float mouseY = Input.GetAxisRaw("Mouse Y") * lookSpeed * Time.deltaTime; // Tekur inn sn�ning � Y-�s me� m�sinni.
        _xRotation += mouseY; // B�tir vi� sn�ningnum � X-�s.
        _xRotation = Mathf.Clamp(_xRotation, maxLookDownAngle, maxLookUpAngle); // Kallar � Mathf.Clamp() til a� takmarka sn�ninginn � milli l�gmarks og h�marks gilda.
        _yRotation += mouseX; // B�tir vi� sn�ningnum � Y-�s.
        transform.localRotation = Quaternion.Euler(-_xRotation, _yRotation, 0f); // Sn�r leikmanninum � r�tta �tt me� n�ju sn�ningi.
    }
}
