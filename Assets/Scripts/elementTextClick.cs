using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class elementTextClick : MonoBehaviour
{
    public TMP_InputField mainField;
    

    public void setMainFieldText(){
        
       mainField.text =  GetComponent<TextMeshProUGUI>().text ;
       Debug.Log("Clickedddd");
    }
}
