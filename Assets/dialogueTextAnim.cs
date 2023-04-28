using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialogueTextAnim : MonoBehaviour
{
    public char[] contentArr; 
    public int pointerInd ;
    public string message;
    public bool messageDone;
    // Start is called before the first frame update
    void Start()
    {
        contentArr = message.ToCharArray();
        pointerInd = 0 ; 
        GetComponent<TextMeshProUGUI>().text = "";
        StartCoroutine("wordTypeWriterEffect");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startAnim(){
        GetComponent<TextMeshProUGUI>().text = "";
        pointerInd = 0 ; 
        contentArr = message.ToCharArray();
        StartCoroutine("wordTypeWriterEffect");
        
    }

    IEnumerator wordTypeWriterEffect(){
        messageDone = false;
        while(pointerInd < contentArr.Length){
            string currentText = GetComponent<TextMeshProUGUI>().text; 
            
            currentText += contentArr[pointerInd];
            GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(0.06f);
            
            
            pointerInd += 1 ;
        }
        messageDone = true;

    }
}
