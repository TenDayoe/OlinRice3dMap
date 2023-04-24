using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class tempBannerTextUpdate : MonoBehaviour
{
    public TMP_Text banner; 
    public Sprite left; 
    public Sprite right; 
    public Sprite straight;
    public Sprite nullSprite;
    public Sprite finished;
    public GameObject imgObj;
    // Start is called before the first frame update
    public void updateText(string text,string direction){
        banner.text = text;
        if (direction == "right"){
            imgObj.GetComponent<Image>().sprite  = right;
        }else if(direction == "left"){
            imgObj.GetComponent<Image>().sprite  = left;
        }else if(direction == "straight"){
            imgObj.GetComponent<Image>().sprite  = straight;
        }else if(direction == "finished"){
            imgObj.GetComponent<Image>().sprite  = finished;
        }else{
            imgObj.GetComponent<Image>().sprite  = nullSprite;
        }
    }
}
