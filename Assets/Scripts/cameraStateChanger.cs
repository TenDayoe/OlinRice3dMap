using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraStateChanger : MonoBehaviour
{
    public string defaultState = "thirdPerson";
    public string currentState ;
    public Camera camera;
    public GameObject agent;
    public float displacement ;
    // Start is called before the first frame update
    void Start()
    {
        currentState = "thirdPerson";
    }

    public void stateChange() {
    if (currentState == "fpv") {
        Vector3 tempPos = camera.transform.position -(agent.transform.forward) * displacement;
        camera.transform.position = tempPos;
        currentState = "thirdPerson";
    } else if (currentState == "thirdPerson") {
        currentState = "fpv";
        Vector3 tempPos = camera.transform.position + (agent.transform.forward) * displacement;
        camera.transform.position = tempPos;
    }
}
}
