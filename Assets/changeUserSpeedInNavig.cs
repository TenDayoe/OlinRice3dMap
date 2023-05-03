using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeUserSpeedInNavig : MonoBehaviour
{
    
    void Start(){
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("UserSpeed")/2;
    }
    // Update is called once per frame
    public void changeInNavigationUserSpeed()
    {
        PlayerPrefs.SetFloat("UserSpeed",GetComponent<Slider>().value * 2 );
    }
}
