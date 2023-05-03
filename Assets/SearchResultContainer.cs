using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SearchResultContainer : MonoBehaviour
{
    public List<string>  searchResults; 
    public TMP_InputField field; 
    public List<string> dummy ; 
    public GameObject scrollview;
    public GameObject element;
    // Start is called before the first frame update
    void Start()
    {
        dummy = new List<string>(){
            "apple",
            "ball",
            "boss"
        };
    }
    public void displayResults(){
        //use generate a list of  
    }
    public void disableScrollView(){
        scrollview.SetActive(false);
    }
    public void enableScrollView(){
        scrollview.SetActive(true);
    }
    
    public void generateResults(){
        
            scrollview.SetActive(true);
            string query = field.text ;
            searchResults = new List<string>();
            foreach(string s in dummy){
                if(s.Contains(query)){
                    searchResults.Add(s);
                }
            }
            int c = 0 ; 
            foreach (string res in searchResults){
                GameObject j = Instantiate(element, new Vector3(-40f,-1*(c * 20f),0f),Quaternion.identity, transform );
                j.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = res;
                j.transform.localPosition = new Vector3(0f,c * 10,0f);
                j.GetComponent<elementTextClick>().mainField = field;
                c+=1;
            }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
