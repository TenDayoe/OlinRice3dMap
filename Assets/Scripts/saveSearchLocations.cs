using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class saveSearchLocations : MonoBehaviour
{
    public GameObject currentLocationEntry; 
    public GameObject destinationEntry;
    public GameObject elevatorToggle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void savePlayerPref(){
        if(elevatorToggle.GetComponent<Toggle>().isOn){
            PlayerPrefs.SetString("usingElevator", "yes");
        }else{
            PlayerPrefs.SetString("usingElevator","no");
        }
        PlayerPrefs.SetString("currentLocation", currentLocationEntry.GetComponent<TMP_Text>().text);
        PlayerPrefs.SetString("destination", destinationEntry.GetComponent<TMP_Text>().text);
        
    }
}
