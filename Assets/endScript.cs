using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endScript : MonoBehaviour
{
    public GameObject infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndTrip(){
        infoPanel.GetComponent<MessagePromptBoardManager>().state = "Init";
        PlayerPrefs.SetString("currentLocation", "");
        PlayerPrefs.SetString("destination","");
        SceneManager.LoadScene("MainMenu");
    }
}
