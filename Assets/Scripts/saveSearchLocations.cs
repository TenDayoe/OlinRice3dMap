using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class saveSearchLocations : MonoBehaviour
{
    public GameObject currentLocationEntry; 
    public GameObject destinationEntry;

    public void savePlayerPref(){
        PlayerPrefs.SetString("currentLocation", currentLocationEntry.GetComponent<TMP_Text>().text);
        PlayerPrefs.SetString("destination", destinationEntry.GetComponent<TMP_Text>().text);
    }
}
