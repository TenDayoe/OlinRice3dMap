using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDownItems : MonoBehaviour
{
    public List<GameObject> contentList;
    public List<string> domain;
    public string query; 
    public GameObject elementObjectPrefab;
    public float currentTail; 
    public float componentHeight; 
    public float padding;

    // Start is called before the first frame update
    void Start()
    {
        generateContentList(query);
    }
    public void generateContentList(string q){
        query = q;
        List<string> tempResults = new List<string>();
        foreach(string s in domain ){
            if (s.Contains(query))
                tempResults.Add(s);
        }
        int c = 0 ;
        foreach (string s in tempResults){
            Vector3 position = new Vector3(0, (-c * (componentHeight + padding) )  -400 , 0);
            GameObject j = Instantiate(elementObjectPrefab, transform);
            Debug.Log(j.transform.localPosition);
        }
        

    }

    void populate(){

    }
}
