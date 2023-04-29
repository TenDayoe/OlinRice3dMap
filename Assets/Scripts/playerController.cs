using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using TMPro;
public class playerController : MonoBehaviour
{
    
    public GameObject destination;
    public NavMeshAgent agent;
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

    //Check point features

    public GameObject bannerText;
    public float stepsLeftUntilCheckPoint;
    private void Start()
    {
        
        currentLocation = PlayerPrefs.GetString("currentLocation").Substring(0, PlayerPrefs.GetString("currentLocation").Length - 1);
        destinationLocation = PlayerPrefs.GetString("destination").Substring(0, PlayerPrefs.GetString("destination").Length -1 );
        //Elevator Features 
        usingElevator = PlayerPrefs.GetString("usingElevator");
        Debug.Log(usingElevator);
        floorReached = false;
        if (usingElevator == "yes"){

            currentFloor = currentLocation[2];
            destFloor = destinationLocation[2];

            if (int.Parse(currentFloor.ToString()) !=int.Parse(destFloor.ToString()) ){
                elev1 = "ElevatorFloorMarker" + currentFloor;
                elev2 = "ElevatorFloorMarker" + destFloor;
                destinationLocation = elev1;
                
                
                
            }else{
                usingElevator = "no";
            }

        }
        
        
        Debug.Log(currentLocation);
        transform.position = GameObject.Find(currentLocation).transform.Find("point").position;
        agent.Warp(transform.position);
        
        destination = GameObject.Find(destinationLocation).transform.Find("point").gameObject;
        agent.SetDestination(destination.transform.position);
        GameObject destinationPointer = GameObject.Find("DestinationPointer");
        tempForwardHolder = agent.transform.forward;
        Vector3 destinationPointerPos = destination.transform.position;
        destinationPointerPos.y -= 0.9f;
        destinationPointer.transform.position = destinationPointerPos;

    }
    
     
    private void updateCheckPoints(){
        float currentStepCount;
        if (agent.path.corners.Length >=2){
            currentStepCount = Mathf.Round(Vector3.Distance(transform.position, agent.path.corners[1])/2);
        }else{
        currentStepCount = 0 ; 
        }
        string message ;
        if (stepsLeftUntilCheckPoint != currentStepCount){
            if(currentStepCount > 2f && agent.path.corners.Length > 2){
                stepsLeftUntilCheckPoint = currentStepCount; 
                

                Vector3 agentToChPointVector = (agent.path.corners[1] - transform.position).normalized; 
                Vector3 agentToNextChPointVector = (agent.path.corners[2] - transform.position).normalized;


                Vector3 crossProduct = Vector3.Cross(agentToNextChPointVector, agentToChPointVector); 
                string direction;
                if (crossProduct ==  Vector3.zero){
                    message = "Keep going straight for " + currentStepCount.ToString() + " steps";
                    direction = "straight";
                }else if(crossProduct.y < 0){
                    message = "Turn right after " + currentStepCount.ToString() + " steps";
                    direction = "right";
                }else{
                    direction = "left";
                    message = "Turn left after " + currentStepCount.ToString() + " steps";
                }
                bannerText.GetComponent<tempBannerTextUpdate>().updateText(message,direction);
                
            }else{
                if (bannerText.GetComponent<TMP_Text>().text != ""){
                    bannerText.GetComponent<tempBannerTextUpdate>().updateText("","N/A");
                }
            }
        }
    }
        
    
    private void Update()
    {
        //remove 
        
        updateCheckPoints();


        if (transform.position.y < 4.5f){
                floorText.text = "Floor 1";
                
            }else if (transform.position.y >4.5f && transform.position.y < 13.5f){
               floorText.text = "Floor 2";
            }
            else {
                floorText.text = "Floor 3";
        }
        // //
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, Vector3.down, out hit))
        // {
        //     // Get the object that was hit
        //     GameObject hitObject = hit.collider.gameObject;
        //     if (transform.position.y < 4.5f){
        //         floorText.text = "Floor 1";
        //         camera.cullingMask = (1 << LayerMask.NameToLayer("floor1")| 1 << LayerMask.NameToLayer("player")|1 << LayerMask.NameToLayer("UI"));
        //     }else if (transform.position.y >4.5f && transform.position.y < 13.5f){
        //        floorText.text = "Floor 2";
        //        camera.cullingMask = (1 << LayerMask.NameToLayer("floor1") | 1 << LayerMask.NameToLayer("floor2") | 1 << LayerMask.NameToLayer("player")|1 << LayerMask.NameToLayer("UI"));
        //     }
        //     else {
        //         floorText.text = "Floor 3";
        //         camera.cullingMask = (1 << LayerMask.NameToLayer("floor1") | 1 << LayerMask.NameToLayer("floor2") | 1 << LayerMask.NameToLayer("floor3")| 1 << LayerMask.NameToLayer("player")|1 << LayerMask.NameToLayer("UI"));
        //     }
        // }

        if (agent.path != null)
        {
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;
            lineRenderer.positionCount = agent.path.corners.Length;
            lineRenderer.SetPositions(agent.path.corners);

            
        }
        
        elevatorManagement();
    }

    void elevatorManagement(){
        
        if(usingElevator == "yes" && floorReached == false){

            if(Vector3.Distance(transform.position, GameObject.Find(elev1).transform.position)<2f && elev1Reached == false){
                
                elevator.GetComponent<elevator>().currentFloor = int.Parse(currentFloor.ToString());
                elevator.GetComponent<elevator>().floorLevel = int.Parse(destFloor.ToString());
                if(currentFloor == '1'){
                    elevator.transform.localPosition = new Vector3(elevator.transform.localPosition.x, elevator.GetComponent<elevator>().floor1Y, elevator.transform.localPosition.z);
                }else if (currentFloor == '2'){
                    elevator.transform.localPosition = new Vector3(elevator.transform.localPosition.x, elevator.GetComponent<elevator>().floor2Y, elevator.transform.localPosition.z);
                }else{
                    elevator.transform.localPosition = new Vector3(elevator.transform.localPosition.x, elevator.GetComponent<elevator>().floor3Y, elevator.transform.localPosition.z);
                }
                
                elev1Reached = true;
                Debug.Log("Reached Elev1");
                
                camera.gameObject.SetActive(false);
                elevatorCam.gameObject.SetActive(true);
                GetComponent<Animator>().SetBool("isHappy",true);
                
                agent.isStopped = true;
                Vector3 tempMarkerPos = new Vector3(-10,-10,-10);
                GameObject.Find("DestinationPointer").transform.position = tempMarkerPos;
            }
            if(elevator.GetComponent<elevator>().currentFloor == elevator.GetComponent<elevator>().floorLevel && elevator.GetComponent<elevator>().floorLevel == int.Parse(destFloor.ToString()) && elev1Reached == true){
                Debug.Log("Destination reached");
                floorReached = true; 
                elevatorCam.gameObject.SetActive(false);
                camera.gameObject.SetActive(true);
                
                
                //setting the destination location

                //made changes here
                GetComponent<Animator>().SetBool("isHappy",false);
                destinationLocation = PlayerPrefs.GetString("destination").Substring(0, PlayerPrefs.GetString("destination").Length -1 );
                destination = GameObject.Find(destinationLocation).transform.Find("point").gameObject;

                //setting the starting location
                
                transform.position = GameObject.Find(elev2).transform.position;
                agent.Warp(transform.position);
                agent.SetDestination(destination.transform.position);
                tempForwardHolder = agent.transform.forward;
                Vector3 destinationPointerPos = destination.transform.position;
                destinationPointerPos.y -= 0.9f;
                GameObject.Find("DestinationPointer").transform.position = destinationPointerPos;
            }
           
        }else if (usingElevator == "yes" && floorReached == true){
            if (Vector3.Distance(transform.position, GameObject.Find(destinationLocation).transform.position) < 4){
                bannerText.GetComponent<tempBannerTextUpdate>().updateText("Destination Reached","finished");
                
                if(GetComponent<Animator>().GetBool("destinationReached") == false)
                {
                    agent.Stop();
                    GetComponent<Animator>().SetBool("destinationReached",true);
                    camera.transform.parent = null;
                    
                    
                    Debug.Log("Animation done!");
                }
                transform.LookAt(transform.position + camera.transform.rotation * Vector3.back,camera.transform.rotation * Vector3.up);
                camera.transform.LookAt(camera.transform.position + transform.rotation * Vector3.back,transform.rotation * Vector3.up);
                
            }
        }
    }
}