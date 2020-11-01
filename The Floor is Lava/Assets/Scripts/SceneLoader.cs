using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex = 0;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }
}
