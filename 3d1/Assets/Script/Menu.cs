using UnityEngine;
using UnityEngine.SceneManagement; // To allow scene management

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    // This function can be called by the button
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name not set or invalid!");
        }
    }
}
