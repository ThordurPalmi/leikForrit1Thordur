using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;//Hva�a sena

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);//breyti um senu
    }
    public void QuitGame()
    {
        Application.Quit(); // st��va leikinn
    }
}
