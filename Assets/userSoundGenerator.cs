using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class userSoundGenerator : MonoBehaviour
{
    [SerializeField]
    private AudioClip elevatorSound;
    [SerializeField]
    private AudioClip victorySound;
    public void playElevatorSound()
    {
        try{
            SoundManager.Instance.PlaySFX(elevatorSound);
        }catch(Exception e){
            Debug.Log("Sound Object does not exist");
        }
    }
    public void playVictorySound(){
    try{
        SoundManager.Instance.PlaySFX(victorySound);
        }catch(Exception e){
            Debug.Log("Sound Object does not exist");
        }
    }
}
