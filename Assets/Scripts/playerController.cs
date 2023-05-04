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
    private void Start()
    {
    
        string currentLocation = "OL" + PlayerPrefs.GetString("currentLocation").Substring(0, PlayerPrefs.GetString("currentLocation").Length - 1);
        string destinationLocation = "OL"+ PlayerPrefs.GetString("destination").Substring(0, PlayerPrefs.GetString("destination").Length -1 );
        
        transform.position = GameObject.Find(currentLocation).transform.position;
        agent.Warp(transform.position);
        destination = GameObject.Find(destinationLocation);
        agent.SetDestination(destination.transform.position);
        GameObject destinationPointer = GameObject.Find("DestinationPointer");

        Vector3 destinationPointerPos = destination.transform.position;
        destinationPointerPos.y -= 0.9f;
        destinationPointer.transform.position = destinationPointerPos;
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
            
        }
    }
}