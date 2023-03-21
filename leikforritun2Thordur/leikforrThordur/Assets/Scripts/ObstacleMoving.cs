using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    public float moveDistance = 5f;     // The distance the obstacle moves
    public float moveSpeed = 2f;        // The speed at which the obstacle moves
    public bool moveAlongX = true;      // Whether to move the obstacle along the X or Z axis

    private Vector3 startPos;           // The starting position of the obstacle
    private bool movingForward = true;  // Whether the obstacle is currently moving forward or backward

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the obstacle
        if (moveAlongX)
        {
            if (movingForward)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.right * moveDistance, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (movingForward)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.forward * moveDistance, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            }
        }

        // Change direction if the obstacle has reached its move distance
        if (moveAlongX)
        {
            if (transform.position.x >= startPos.x + moveDistance)
            {
                movingForward = false;
            }
            else if (transform.position.x <= startPos.x)
            {
                movingForward = true;
            }
        }
        else
        {
            if (transform.position.z >= startPos.z + moveDistance)
            {
                movingForward = false;
            }
            else if (transform.position.z <= startPos.z)
            {
                movingForward = true;
            }
        }
    }
}
