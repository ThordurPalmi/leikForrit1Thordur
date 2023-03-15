using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topDestroyLength = 30.0f;
    private float bottomDestroyLength = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topDestroyLength)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomDestroyLength)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
