using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manageUserSpeed : MonoBehaviour
{
    public GameObject userCharacter ; 

    public void changeUserSpeed(){
        float sliderVal = GetComponent <Slider> ().value;
        userCharacter.GetComponent<Animator>().speed = sliderVal *2;
    }
}
