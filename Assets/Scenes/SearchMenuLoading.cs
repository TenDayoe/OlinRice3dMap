using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SearchMenuLoading : MonoBehaviour
{
    public void LoadNavigationScene()
    {
        // PlayerPrefs.SetString("currentLocation", currentLocationEntry.GetComponent<TMP_Text>().text);
        // PlayerPrefs.SetString("destination", destinationEntry.GetComponent<TMP_Text>().text);
        StartCoroutine(LoadSceneAsync("Navigation"));
        
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
    Debug.Log("Loading scene: " + sceneName);
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LoadingScene");

    while (!asyncLoad.isDone)
    {
        Debug.Log("Loading progress: " + asyncLoad.progress);
        yield return null;
    }

    Debug.Log("Loading completed, now loading scene: " + sceneName);
    asyncLoad = SceneManager.LoadSceneAsync(sceneName);

    while (!asyncLoad.isDone)
    {
        Debug.Log("Loading progress: " + asyncLoad.progress);
        yield return null;
    }

    Debug.Log("Loading completed: " + sceneName);
    }

}