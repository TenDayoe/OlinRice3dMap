using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialNextDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void getNextDialogue(){
        if(DialogueBox.GetComponent<tutorialManager>().dialogueScript.messageDone = true){
                DialogueBox.GetComponent<tutorialManager>().currentInstIndex++;
                if (DialogueBox.GetComponent<tutorialManager>().currentInstIndex < DialogueBox.GetComponent<tutorialManager>().dialogueList.Count)
                {
                    DialogueBox.GetComponent<tutorialManager>().dialogueScript.message = DialogueBox.GetComponent<tutorialManager>().dialogueList[DialogueBox.GetComponent<tutorialManager>().currentInstIndex];
                    DialogueBox.GetComponent<tutorialManager>().mainInputsRefresh();
                    DialogueBox.GetComponent<tutorialManager>().dialogueScript.startAnim();
                }
        }
    }
}
