using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstTimeUserChecker : MonoBehaviour
{
    void Start(){
        PlayerPrefs.DeleteAll();//This is just for testing ... Remove for final build
    }
    // Start is called before the first frame update
    public void startApp(){


        Debug.Log(PlayerPrefs.GetString("NewUser"));
        if (!PlayerPrefs.HasKey("NewUser")){
            PlayerPrefs.SetString("NewUser","No");
            StartCoroutine("wait");
            SceneManager.LoadScene("Tutorial");
        }else{
            SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
