using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 5f;
    [SerializeField] private float maxLookUpAngle = 90f;
    [SerializeField] private float maxLookDownAngle = -90f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Look
        float mouseX = Input.GetAxisRaw("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * lookSpeed * Time.deltaTime;
        _xRotation += mouseY;
        _xRotation = Mathf.Clamp(_xRotation, maxLookDownAngle, maxLookUpAngle);
        _yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(-_xRotation, _yRotation, 0f);
    }
}
