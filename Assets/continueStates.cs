using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueStates : MonoBehaviour
{
    public GameObject agent;
    public GameObject parentPanel;
    public void ContinueNav(){
        agent.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
        parentPanel.SetActive(false);
        agent.GetComponent<Animator>().SetBool("isHappy",false);
        agent.GetComponent<Animator>().Play("a_Walking");
    }
}
