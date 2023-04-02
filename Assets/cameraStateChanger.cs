using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraStateChanger : MonoBehaviour
{
    public string defaultState = "thirdPerson";
    public string currentState ;
    public Camera camera;
    public float displacement = 10f;
    // Start is called before the first frame update
    void Start()
    {
        currentState = "thirdPerson";
    }

    public void stateChange(){
        if (currentState ==  "birdEye"){
            currentState = "thirdPerson";
            Vector3 tempPos=  camera.transform.position; 
            tempPos.y -= displacement;
            
            camera.transform.position = tempPos;
            camera.transform.Rotate(-30.0f, 0.0f, 0.0f, Space.Self);
        }else if(currentState == "thirdPerson"){
            currentState = "birdEye";
            Vector3 tempPos=  camera.transform.position; 
            tempPos.y += displacement;
            
            camera.transform.position = tempPos;
            camera.transform.Rotate(30.0f, 0.0f, 0.0f, Space.Self);
        }
    }
}
