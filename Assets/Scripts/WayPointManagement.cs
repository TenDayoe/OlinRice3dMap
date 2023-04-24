using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManagement : MonoBehaviour
{
    public LineRenderer lRenderer; 
    public bool wayPointsAdded;
    public GameObject wayPointObject;
    void Start(){
        wayPointsAdded = false;
    }
    // Update is called once per frame
    void Update()
    {
        // if (!wayPointsAdded){
        //     int counter = 0 ; 
        //     Vector3[] temp = lRenderer.GetPositions();
        //     foreach(Vector3 v in temp){
        //         if (counter >0){
        //             Instantiate(wayPointObject,v, Quaternion.Identity );
        //         }else{
        //             counter += 1; 
        //         }
                
        //     }
        // }
    
    }
}
