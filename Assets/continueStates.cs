using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueStates : MonoBehaviour
{
    public GameObject agent;
    public GameObject parentPanel;
    public GameObject endButton;
    public void ContinueNav(){
        if(parentPanel.GetComponent<MessagePromptBoardManager>().state != "Dest"){

        
        agent.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
        parentPanel.SetActive(false);
        agent.GetComponent<Animator>().SetBool("isHappy",false);
        agent.GetComponent<Animator>().Play("a_Walking");
        }else{
            endButton.GetComponent<endScript>().EndTrip();
        }   
    }
}
