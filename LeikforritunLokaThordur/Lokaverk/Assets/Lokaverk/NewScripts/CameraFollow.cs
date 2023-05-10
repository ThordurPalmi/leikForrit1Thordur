using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Tengi á leikmanns-object-inu sem myndavélin á að fylgjast með
    public Transform playerTransform;
    // Hraði myndavélarinnar þegar hún fylgist með leikmanninum
    public float smoothSpeed = 0.125f;
    // Forskipting á milli leikmanns og myndavélar
    public Vector3 offset;

    void FixedUpdate()
    {
        // Staðsetningin sem myndavélin á að vera á, sem er leikmannsstaðsetningin plús forskeytingin
        Vector3 desiredPosition = playerTransform.position + offset;
        // "Lerp" fallið láðar hægar inn á nýja staðsetningu myndavélarinnar til að mynda smuða fylgjandi hreyfingu
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Staðsetning myndavélarinnar verður núna nýja smuða staðsetningin
        transform.position = smoothedPosition;
    }
}
