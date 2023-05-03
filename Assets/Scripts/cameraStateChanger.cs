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

    public void stateChange() {
    if (currentState == "fpv") {
        currentState = "thirdPerson";
        Vector3 displacementVector = new Vector3(displacement, 0, 0);
        Vector3 tempPos = camera.transform.position + camera.transform.TransformDirection(displacementVector);
        camera.transform.position = tempPos;
    } else if (currentState == "thirdPerson") {
        currentState = "fpv";
        Vector3 displacementVector = new Vector3(-displacement, 0, 0);
        Vector3 tempPos = camera.transform.position + camera.transform.TransformDirection(displacementVector);
        camera.transform.position = tempPos;
    }
}
}
