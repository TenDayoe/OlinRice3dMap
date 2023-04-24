using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endScript : MonoBehaviour
{
    public void EndTrip(){
        PlayerPrefs.SetString("currentLocation", "");
        PlayerPrefs.SetString("destination","");
        SceneManager.LoadScene("SearchMenu");
    }
}
