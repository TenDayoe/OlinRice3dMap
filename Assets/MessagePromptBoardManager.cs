

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessagePromptBoardManager : MonoBehaviour
{
    public int destFloor; 
    public string state ; 

    public TextMeshProUGUI messageText;
    // Start is called before the first frame update
    public void create(){
        if (state == "Init"){
            messageText.text = "Are you ready to start ?";
        }else if (state == "InElev"){
            messageText.text = "Have you reached floor " + destFloor; 
        }else if ( state == "Dest"){
            messageText.text = "End trip?";
        }
    }
}
