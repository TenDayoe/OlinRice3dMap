using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorCheck : MonoBehaviour
{
    public string floor; 

    void OnCollisionEnter(Collision collision) {
        Transform collidedObjectTransform = collision.gameObject.transform;
        floor = collidedObjectTransform.name;
        Debug.Log("Player collided with: " + collidedObjectTransform.name);
    }

}
