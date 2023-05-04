using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class pausePlayAgent : MonoBehaviour
{
    public GameObject agentObj; 
    public bool isPlaying;
    public Sprite pause;
    public Sprite play;
    public Image img;
    void Start(){
        isPlaying = true;
    }
    public void pausePlayUser(){
        if (isPlaying == true){
            isPlaying = false; 
            img.sprite = play;
            agentObj.GetComponent<playerController>().agent.Stop();
            agentObj.GetComponent<Animator>().SetBool("isHappy",true);
        }
        else{
            isPlaying = true; 
            img.sprite = pause; 
            agentObj.GetComponent<playerController>().agent.Resume();
            agentObj.GetComponent<Animator>().SetBool("isHappy",false);
            agentObj.GetComponent<Animator>().Play("a_Walking");
        }
    }

    
}
