using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Camera mainCamera;
    public float scaleFactor = 1.0f;

    void Start()
    {
        // Create a new GameObject to hold the background sprite
        GameObject backgroundObject = new GameObject("Background");

        // Set the background sprite as a child of the new GameObject
        transform.SetParent(backgroundObject.transform);

        // Set the position of the new GameObject to match the camera's position
        backgroundObject.transform.position = mainCamera.transform.position;

        // Set the scale of the new GameObject to match the camera's size
        float height = mainCamera.orthographicSize * 2.0f;
        float width = height * mainCamera.aspect;
        backgroundObject.transform.localScale = new Vector3(width * scaleFactor, height * scaleFactor, 1.0f);
    }
}
