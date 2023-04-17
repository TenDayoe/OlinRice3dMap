using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tempBannerTextUpdate : MonoBehaviour
{
    public TMP_Text banner; 
    // Start is called before the first frame update
    public void updateText(string text){
        banner.text = text;
    }
}
