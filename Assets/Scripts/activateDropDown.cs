using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class activateDropDown : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown ddown;
    public void activateDdown(){
        ddown.Show();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
