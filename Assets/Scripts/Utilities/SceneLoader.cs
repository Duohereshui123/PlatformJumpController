using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneIndex >= SceneManager.sceneCount)
        {
            //加载合适的场景 比如开始场景。现在用reloadsceen代替
            ReloadScene();
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}