using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Tengi � leikmanns-object-inu sem myndav�lin � a� fylgjast me�
    public Transform playerTransform;
    // Hra�i myndav�larinnar �egar h�n fylgist me� leikmanninum
    public float smoothSpeed = 0.125f;
    // Forskipting � milli leikmanns og myndav�lar
    public Vector3 offset;

    void FixedUpdate()
    {
        // Sta�setningin sem myndav�lin � a� vera �, sem er leikmannssta�setningin pl�s forskeytingin
        Vector3 desiredPosition = playerTransform.position + offset;
        // "Lerp" falli� l��ar h�gar inn � n�ja sta�setningu myndav�larinnar til a� mynda smu�a fylgjandi hreyfingu
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Sta�setning myndav�larinnar ver�ur n�na n�ja smu�a sta�setningin
        transform.position = smoothedPosition;
    }
}
