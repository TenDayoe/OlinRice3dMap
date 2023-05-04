using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class key : MonoBehaviour
{
    public string val; 
    public GameObject Holder = null;
    
    public void changeHolderVal(){ 
        string original = Holder.transform.Find("TextVal").GetComponent<TextMeshProUGUI>().text;
        if (val!="BackSpace"){
            if(original.Length<3)
            Holder.transform.Find("TextVal").GetComponent<TextMeshProUGUI>().text += val;
        }else{
            if(original.Length>0){
                Debug.Log("Backspace pressed");
                Holder.transform.Find("TextVal").GetComponent<TextMeshProUGUI>().text = original.Substring(0,original.Length - 1);
            
            }
        }
        Holder.GetComponent<InputButton>().InvokeSearch();
        
    }
    
}
