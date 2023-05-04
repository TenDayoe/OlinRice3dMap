using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class levelLoader : MonoBehaviour
{
    public GameObject button;
    public GameObject spinner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadMapScene(string sceneName){
        if(SceneManager.GetActiveScene().name != "SetWalkingSpeed"){
            if (button.GetComponent<navigateOnClick>().currentLocationEntry.GetComponent<InputButton>().roomList.Contains(button.GetComponent<navigateOnClick>().currentLocationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text) &&button.GetComponent<navigateOnClick>().currentLocationEntry.GetComponent<InputButton>().roomList.Contains( button.GetComponent<navigateOnClick>().destinationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text)
            && button.GetComponent<navigateOnClick>().currentLocationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text != button.GetComponent<navigateOnClick>().destinationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text){
                button.SetActive(false);
                spinner.SetActive(true);
                if(PlayerPrefs.HasKey("UserSpeed")){
                    StartCoroutine(AsyncSceneLoader(sceneName));
                }else{
                    SceneManager.LoadScene("SetWalkingSpeed");
                }
        }
        }else{
            button.SetActive(false);
            spinner.SetActive(true);
            if(PlayerPrefs.HasKey("UserSpeed")){
                StartCoroutine(AsyncSceneLoader(sceneName));
            }else{
                SceneManager.LoadScene("SetWalkingSpeed");
            }
        }
        // if(button.GetComponent<navigateOnClick>().isValid){
        //     button.SetActive(false);
        //     spinner.SetActive(true);
        //     if(PlayerPrefs.HasKey("UserSpeed")){
        //         StartCoroutine(AsyncSceneLoader(sceneName));
        //     }else{
        //         SceneManager.LoadScene("SetWalkingSpeed");
        //     }
        // }else{
        //     Debug.Log("not a valid entry");
        // }
        
        
    }


    private IEnumerator AsyncSceneLoader(string sceneName){
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        
        while(loading.isDone != true){
            
            yield return null;
        }
        
    }
}
