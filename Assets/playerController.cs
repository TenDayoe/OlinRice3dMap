using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
public class playerController : MonoBehaviour
{
    public GameObject destination;
    public NavMeshAgent agent;
    public LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            agent.SetDestination(destination.transform.position);
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