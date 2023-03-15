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
        //ef maturinn kemst out of bounds
        if (transform.position.z > topDestroyLength)
        {
            Destroy(gameObject);
        }
        //ef animal kemst out of bounds
        else if (transform.position.z < bottomDestroyLength)
        {
            //skrifa að leikurinn endar og eyðinlegg objectið sem fór out of bounds
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
