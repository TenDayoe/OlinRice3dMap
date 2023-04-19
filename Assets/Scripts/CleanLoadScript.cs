using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CleanLoadScript : MonoBehaviour
{
    // The names of the scenes to load
    public string titleScene = "SearchMenu";
    public string loadingScene = "LoadingScene";
    public string gameplayScene = "Navigation";
 
    // Load the loading scene and then start loading the gameplay scene
    public void LoadGameplayScene()
    {
        Debug.Log("Starting LoadGameplayScene()");

        StartCoroutine(LoadGameplaySceneAsync());
    }

    // Load the gameplay scene asynchronously
    private IEnumerator LoadGameplaySceneAsync()
    {
        Debug.Log("Loading " + loadingScene + " scene");

        // Load the loading scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadingScene);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            // Update progress bar or loading screen here
            Debug.Log("Loading " + loadingScene + ": " + (asyncLoad.progress * 100) + "%");

            yield return null;
        }

        // Activate the loading scene
        asyncLoad.allowSceneActivation = true;

        Debug.Log("Loading " + gameplayScene + " scene");

        // Wait until the gameplay scene is loaded
        asyncLoad = SceneManager.LoadSceneAsync(gameplayScene);

        while (!asyncLoad.isDone)
        {
            // Update progress bar or loading screen here
            Debug.Log("Loading " + gameplayScene + ": " + (asyncLoad.progress * 100) + "%");

            yield return null;
        }

        Debug.Log("Finished loading " + gameplayScene + " scene");
    }
}
