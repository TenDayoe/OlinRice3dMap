using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public GameObject currentActive; 
    // Start is called before the first frame update
    void Start()
    {
        currentActive = null;
    }

    public void resetCurrentObjectForChildren(){
        foreach(Transform child in transform){
            transform.gameObject.GetComponent<key>().Holder = currentActive; 
        }
    }
    
}
