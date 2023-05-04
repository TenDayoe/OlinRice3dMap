using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCorrectLayerInnerBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent!= null){
            gameObject.layer = transform.parent.gameObject.layer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
