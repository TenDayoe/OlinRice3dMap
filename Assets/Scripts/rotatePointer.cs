using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePointer : MonoBehaviour
{

    public float rotationRate = 0.8f; // Rotation rate in degrees per second

void Update()
{
    // Rotate the object around the y-axis
    transform.Rotate(0, rotationRate * Time.deltaTime, 0);
}

}
