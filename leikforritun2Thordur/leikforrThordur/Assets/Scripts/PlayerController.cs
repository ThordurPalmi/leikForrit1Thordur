using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;       // hversu harkalega playerinn mun hoppa
    public float moveSpeed = 5f;        // hversu hratt playerinn hreyfir sig
    public float turnSpeed = 5f;        // hversu hratt playerinn sn�r s�r
    public int lives = 3;               // hversu m�rg l�f playerinn byrjar me�
    public float minY = -5f;            // hversu langt ni�ur m� falla ni�ur ��ur en missir l�f

    private Rigidbody rb;

    private bool isGrounded = true;     // fyrir a� t�kka ef player er � j�r� til a� vita ef hann m� hoppa


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position - transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + transform.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * -turnSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * turnSpeed * Time.deltaTime));
        }
        if (Mathf.Abs(transform.eulerAngles.x) > 80 || Mathf.Abs(transform.eulerAngles.z) > 80)
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            if (lives <= 0)
            {
                // Game over
                Debug.Log("Game over!");
            }
            else
            {
                // Respawn the player
                transform.position = new Vector3(0f, 0.5f, 0f);
            }
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < minY)
        {
            lives--;
            if (lives <= 0)
            {
                // Game over
                Debug.Log("Game over!");
            }
            else
            {
                // Respawn the player
                transform.position = new Vector3(0f, 0.5f, 0f);
            }
        }
    }
}
