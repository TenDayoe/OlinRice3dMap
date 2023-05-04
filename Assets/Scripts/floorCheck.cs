using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorCheck : MonoBehaviour
{
    public string floor; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision) {
        
        Transform collidedObjectTransform = collision.gameObject.transform;
        floor = collidedObjectTransform.name;
        Debug.Log("Player collided with: " + collidedObjectTransform.name);
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
