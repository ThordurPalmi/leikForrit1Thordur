using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ef leikma�urinn dettur � vatni�...
        {

            SceneManager.LoadScene(sceneName); // Hle�ur inn � senu sem var gefin upp ��ur.
            Cursor.lockState = CursorLockMode.None; // S�nir m�sarbendilinn aftur.
            Cursor.visible = true; // S�nir m�sarbendilinn aftur.

        }
    }
}
