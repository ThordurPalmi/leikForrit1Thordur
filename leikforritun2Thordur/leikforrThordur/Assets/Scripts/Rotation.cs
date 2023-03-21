using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        //rotatar objectinu
        transform.Rotate(Vector3.up * Time.deltaTime * 50f);
    }
}
