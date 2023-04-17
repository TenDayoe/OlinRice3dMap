using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class roomMarkerTextController : MonoBehaviour
{
    public GameObject labelText;
    public GameObject groundText; 
    void Start()
    {
        transform.Find("Canvas").GetComponent<Canvas>().worldCamera =GameObject.Find("Camera").GetComponent<Camera>();
        labelText =transform.Find("Canvas").Find("labelText").gameObject;
        labelText.GetComponent<TMP_Text>().text = this.gameObject.name;
        groundText = transform.Find("Canvas").Find("groundText").gameObject;
        groundText.GetComponent<TMP_Text>().text = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
