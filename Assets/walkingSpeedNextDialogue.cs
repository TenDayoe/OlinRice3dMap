using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingSpeedNextDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void getNextDialogue(){
        if(DialogueBox.GetComponent<walkingSpeedInstruction>().dialogueScript.messageDone = true){
                DialogueBox.GetComponent<walkingSpeedInstruction>().currentInstIndex++;
                if (DialogueBox.GetComponent<walkingSpeedInstruction>().currentInstIndex < DialogueBox.GetComponent<walkingSpeedInstruction>().dialogueList.Count)
                {
                    DialogueBox.GetComponent<walkingSpeedInstruction>().dialogueScript.message = DialogueBox.GetComponent<walkingSpeedInstruction>().dialogueList[DialogueBox.GetComponent<walkingSpeedInstruction>().currentInstIndex];
                    DialogueBox.GetComponent<walkingSpeedInstruction>().mainInputsRefresh();
                    DialogueBox.GetComponent<walkingSpeedInstruction>().dialogueScript.startAnim();
                }
        }
    }
}
