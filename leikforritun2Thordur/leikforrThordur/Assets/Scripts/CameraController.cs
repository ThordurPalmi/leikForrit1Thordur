using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;               // The player's transform
    public float smoothTime = 0.3f;        // The amount of time it takes for the camera to reach its target position
    public float distance = 5f;            // The distance between the camera and the player
    public Vector3 offset = new Vector3(0f, 2f, 0f);  // The offset from the player's position to the camera's position

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = target.position - distance * target.forward + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(target.position + offset);
    }
}
