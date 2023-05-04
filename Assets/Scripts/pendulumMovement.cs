using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulumMovement : MonoBehaviour
{   
    public float unitV = 1f;
    public float swingSpeed = 1f;
    public float swingMaxDistance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localRotation.x >swingMaxDistance){
            unitV = -1f;
        }else if (transform.localRotation.x <-swingMaxDistance){
            unitV = 1f;
        }
        
        transform.Rotate(unitV * (swingSpeed -Mathf.Abs(transform.localRotation.x)),0f,0f);
        
    }
}
