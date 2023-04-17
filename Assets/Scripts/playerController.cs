using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using TMPro;
public class playerController : MonoBehaviour
{
    
    public GameObject destination;
    public NavMeshAgent agent;
    public NavMeshAgent dummy;
    public LineRenderer lineRenderer;
    public Camera camera;
    public TMP_Text floorText;
    public Vector3 tempForwardHolder;
    public Vector3[] currentCorner; 
    public GameObject elevator;
    //ElevatorFeatures

    public string elev1; 
    public string elev2;
    public bool floorReached ;
    public bool elev1Reached = false;
    public char currentFloor; 
    public char destFloor;
    public string usingElevator;
    private string currentLocation ; 
    private string destinationLocation ;

    
    public Camera elevatorCam;
    private void Start()
    {
        
        currentLocation = "OL" + PlayerPrefs.GetString("currentLocation").Substring(0, PlayerPrefs.GetString("currentLocation").Length - 1);
        destinationLocation = "OL"+ PlayerPrefs.GetString("destination").Substring(0, PlayerPrefs.GetString("destination").Length -1 );
        
        //Elevator Features 
        usingElevator = PlayerPrefs.GetString("usingElevator");
        Debug.Log(usingElevator);
        floorReached = false;
        if (usingElevator == "yes"){

            currentFloor = currentLocation[2];
            destFloor = destinationLocation[2];

            if (currentFloor !=destFloor ){
                elev1 = "ElevatorFloorMarker" + currentFloor;
                elev2 = "ElevatorFloorMarker" + destFloor;
                destinationLocation = elev1;
                
                
            }else{
                usingElevator = "no";
            }

        }
        //
        

        transform.position = GameObject.Find(currentLocation).transform.position;
        agent.Warp(transform.position);
        dummy.Warp(transform.position);
        
        destination = GameObject.Find(destinationLocation);
        dummy.transform.forward = agent.transform.forward;
        agent.SetDestination(destination.transform.position);
        dummy.SetDestination(destination.transform.position);
        GameObject destinationPointer = GameObject.Find("DestinationPointer");
        tempForwardHolder = agent.transform.forward;
        Vector3 destinationPointerPos = destination.transform.position;
        destinationPointerPos.y -= 0.9f;
        destinationPointer.transform.position = destinationPointerPos;
        
    }
    
     
 
    IEnumerator setVelocityDefault()
    {
        yield return new WaitForSeconds(5);
        dummy.speed = agent.speed;
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Get the object that was hit
            GameObject hitObject = hit.collider.gameObject;
            if (transform.position.y < 4.5f){
                floorText.text = "Floor 1";
                camera.cullingMask = (1 << LayerMask.NameToLayer("floor1")| 1 << LayerMask.NameToLayer("player")|1 << LayerMask.NameToLayer("UI"));
            }else if (transform.position.y >4.5f && transform.position.y < 13.5f){
               floorText.text = "Floor 2";
               camera.cullingMask = (1 << LayerMask.NameToLayer("floor1") | 1 << LayerMask.NameToLayer("floor2") | 1 << LayerMask.NameToLayer("player")|1 << LayerMask.NameToLayer("UI"));
            }
            else {
                floorText.text = "Floor 3";
                camera.cullingMask = (1 << LayerMask.NameToLayer("floor1") | 1 << LayerMask.NameToLayer("floor2") | 1 << LayerMask.NameToLayer("floor3")| 1 << LayerMask.NameToLayer("player")|1 << LayerMask.NameToLayer("UI"));
            }
        }

        if (agent.path != null)
        {
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;
            lineRenderer.positionCount = agent.path.corners.Length;
            lineRenderer.SetPositions(agent.path.corners);

            if (Vector3.Dot(tempForwardHolder, dummy.transform.forward) <0.2f){
                Vector3 newReference = dummy.transform.position; 
                Vector3 agentforwardVector= agent.transform.forward; 
                Vector3 dummyforwardVector = agent.transform.forward; 
                tempForwardHolder = dummy.transform.forward;
            }

            
        }
        
        elevatorManagement();
    }

    void elevatorManagement(){
       
        if(usingElevator == "yes" && floorReached == false){

            if(Vector3.Distance(transform.position, GameObject.Find(elev1).transform.position)<2f && elev1Reached == false){
                elevator.GetComponent<elevator>().floorLevel = int.Parse(destFloor.ToString());
                elev1Reached = true;
                Debug.Log("Reached Elev1");
                
                camera.gameObject.SetActive(false);
                elevatorCam.gameObject.SetActive(true);
                
                agent.isStopped = true;
                Vector3 tempMarkerPos = new Vector3(-10,-10,-10);
                GameObject.Find("DestinationPointer").transform.position = tempMarkerPos;
            }
            if(elevator.GetComponent<elevator>().currentFloor == elevator.GetComponent<elevator>().floorLevel && elevator.GetComponent<elevator>().floorLevel == int.Parse(destFloor.ToString())){
                Debug.Log("Destination reached");
                floorReached = true; 
                elevatorCam.gameObject.SetActive(false);
                camera.gameObject.SetActive(true);
                
                
                //setting the destination location
                destinationLocation = "OL"+ PlayerPrefs.GetString("destination").Substring(0, PlayerPrefs.GetString("destination").Length -1 );
                destination = GameObject.Find(destinationLocation);

                //setting the starting location
                
                transform.position = GameObject.Find(elev2).transform.position;
                agent.Warp(transform.position);
                dummy.Warp(transform.position);
                agent.SetDestination(destination.transform.position);
                dummy.SetDestination(destination.transform.position);
                tempForwardHolder = agent.transform.forward;
                Vector3 destinationPointerPos = destination.transform.position;
                destinationPointerPos.y -= 0.9f;
                GameObject.Find("DestinationPointer").transform.position = destinationPointerPos;
            }
           
        }
    }
}