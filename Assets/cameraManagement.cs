using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class cameraManagement : MonoBehaviour
{
    public Camera birdViewCamera;
    public Camera fpvCamera;
    
    void Start()
    {
        birdViewCamera.enabled = true;
        fpvCamera.enabled = false;
    }
    
    public void SwitchCamera()
    {
        birdViewCamera.enabled = !birdViewCamera.enabled;
        fpvCamera.enabled = !fpvCamera.enabled;
    }
}