using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class walkingSpeedInstruction : MonoBehaviour
{
    // Start is called before the first frame update
    public dialogueTextAnim dialogueScript; 
    public List<string> dialogueList = new List<string>(){
        "Now get on your on feet and let's try to sync our walking speed",
        "Just use slider to match our walking speed and when you are done, click on the Confirm button!"

    };
    public int currentInstIndex = 0 ;
    void Start()
    {
       if(currentInstIndex == 0 ){
        dialogueScript.message = dialogueList[currentInstIndex];
        dialogueScript.startAnim();
       }
    }

    public void mainInputsRefresh(){
        if(currentInstIndex ==1){
            dialogueScript.message = dialogueList[currentInstIndex];
            dialogueScript.startAnim();
        }
        else if(currentInstIndex == 2 ){
            this.gameObject.SetActive(false);
        }
    }
    }

