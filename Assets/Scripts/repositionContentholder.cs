using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repositionContentholder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition =    new Vector3 (0,-GetComponent<RectTransform>().rect.height/2 ,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
