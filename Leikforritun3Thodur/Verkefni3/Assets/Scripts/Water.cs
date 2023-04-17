using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ef leikmaðurinn dettur í vatnið...
        {

            SceneManager.LoadScene(sceneName); // Hleður inn í senu sem var gefin upp áður.
            Cursor.lockState = CursorLockMode.None; // Sýnir músarbendilinn aftur.
            Cursor.visible = true; // Sýnir músarbendilinn aftur.

        }
    }
}
