using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public int floorLevel; 
    public float speed; 
    public float floor1Y;
    public float floor2Y;
    public float floor3Y;
    public int currentFloor; 
    public int targetFloor;
    public GameObject doorLeft; 
    public GameObject doorRight; 
    public string state = "closed";
    public float elevatorSpeed;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 unitVector ;
        if(currentFloor < targetFloor){
            unitVector = new Vector3(0,1,0);
        }else{
            unitVector = new Vector3(0,-1,0);
        }


        if (floorLevel == 2 && Mathf.Abs(transform.localPosition.y - floor2Y) >0.1f ){
            transform.Translate(speed * unitVector * Time.deltaTime);
        }else if (floorLevel == 3 &&Mathf.Abs(transform.localPosition.y - floor3Y) >0.1f){
            transform.Translate(speed * unitVector * Time.deltaTime);
        } else if(floorLevel ==1 && Mathf.Abs(transform.localPosition.y - floor1Y)>0.1f){
            transform.Translate(speed  * unitVector * Time.deltaTime);
        }
    }

    public void OpenDoor(){
        StartCoroutine(OpenDoorCoroutine());
    }
     IEnumerator OpenDoorCoroutine(){


        if (state == "closed"){
            while(Mathf.Abs(doorLeft.transform.localPosition.x) + Mathf.Abs(doorRight.transform.localPosition.x) <4f){
                doorLeft.transform.Translate(elevatorSpeed * new Vector3(-1,0,0) * Time.deltaTime);
                doorRight.transform.Translate(elevatorSpeed * new Vector3(1,0,0) * Time.deltaTime);
                yield return new WaitForSeconds(0.07f);
            }
            state = "open";
        }
   }

   IEnumerator CloseDoorCoroutine(){
    if (state =="open"){
            while(Mathf.Abs(doorLeft.transform.localPosition.x) + Mathf.Abs(doorRight.transform.localPosition.x) >1.8f){
                doorLeft.transform.Translate(elevatorSpeed * new Vector3(1,0,0) * Time.deltaTime);
                doorRight.transform.Translate(elevatorSpeed * new Vector3(-1,0,0) * Time.deltaTime);
                yield return new WaitForSeconds(0.07f);
            }
            state = "closed";
        }
   }
    public void CloseDoor(){
        StartCoroutine(CloseDoorCoroutine());
    }
    
}
