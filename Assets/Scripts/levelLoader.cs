using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    public GameObject button;
    public GameObject spinner;

    public void loadMapScene(string sceneName){
        button.SetActive(false);
        spinner.SetActive(true);

        StartCoroutine(AsyncSceneLoader(sceneName));
    }

    private IEnumerator AsyncSceneLoader(string sceneName){
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        
        while(loading.isDone != true){      
            yield return null;
        }
    }
}
