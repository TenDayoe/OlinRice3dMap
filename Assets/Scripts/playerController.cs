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
    private void Start()
    {
    
        string currentLocation = "OL" + PlayerPrefs.GetString("currentLocation").Substring(0, PlayerPrefs.GetString("currentLocation").Length - 1);
        string destinationLocation = "OL"+ PlayerPrefs.GetString("destination").Substring(0, PlayerPrefs.GetString("destination").Length -1 );
        
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
                tempForwardHolder = dummy.transform.forward;
                Debug.Log("Oh dummy has turned ");
                
            }
        }
    }
}