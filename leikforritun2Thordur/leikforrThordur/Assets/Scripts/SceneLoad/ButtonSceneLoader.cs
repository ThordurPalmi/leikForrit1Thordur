using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public string sceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
