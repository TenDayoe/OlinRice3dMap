using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playSoundOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip effectSound;
    public void playSound()
    {
        try{
            SoundManager.Instance.PlaySFX(effectSound);
        }catch(Exception e){
            Debug.Log("Sound Object does not exist");
        }
        

    }
}
