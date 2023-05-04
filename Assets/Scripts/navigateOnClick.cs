using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class navigateOnClick : MonoBehaviour
{
    public GameObject currentLocationEntry; 
    public GameObject destinationEntry;
    public GameObject elevatorToggle;
    public bool isValid;
    void Start()
    {
        isValid = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void savePlayerPref(){

        if (currentLocationEntry.GetComponent<InputButton>().roomList.Contains(currentLocationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text) &&currentLocationEntry.GetComponent<InputButton>().roomList.Contains( destinationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text)){
            if(elevatorToggle.GetComponent<Toggle>().isOn){
            PlayerPrefs.SetString("usingElevator", "yes");
            }else{
                PlayerPrefs.SetString("usingElevator","no");
            }
            PlayerPrefs.SetString("currentLocation", "OL"+currentLocationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text);
            PlayerPrefs.SetString("destination", "OL"+destinationEntry.transform.Find("TextVal").GetComponent<TMP_Text>().text);
            isValid = true;
        }else{
            isValid = false;
        }

        
        
        
    }
}
