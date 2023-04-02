using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class saveSearchLocations : MonoBehaviour
{
    public GameObject currentLocationEntry; 
    public GameObject destinationEntry;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void savePlayerPref(){
       
        PlayerPrefs.SetString("currentLocation", currentLocationEntry.GetComponent<TMP_Text>().text);
        PlayerPrefs.SetString("destination", destinationEntry.GetComponent<TMP_Text>().text);
        SceneManager.LoadScene("Navigation");
    }
}
