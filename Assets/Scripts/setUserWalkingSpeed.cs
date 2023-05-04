using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class setUserWalkingSpeed : MonoBehaviour
{
    public GameObject SliderObject;
    public void setSpeed(){
        PlayerPrefs.SetFloat("UserSpeed",SliderObject.GetComponent<Slider>().value * 2f);
    }

}
