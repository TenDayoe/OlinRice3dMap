using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour
{
    public void LoadNavigationScene()
    {
        SceneManager.LoadScene("Navigation");
    }
}