using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    public dialogueTextAnim dialogueScript; 
    public GameObject curLocationinputField;
    public GameObject destInputField; 
    public GameObject curDropDown; 
    public GameObject destDropDown;
    public GameObject checkBox ; 
    public GameObject navButton;
    public GameObject dlBox;
    public GameObject character;
    public GameObject keyboard;
    public List<string> dialogueList = new List<string>(){
        "Hello, I am Oli. I will be your official Olin Rice navigation guide.",
        "First of all, Welcome to Olin Rice!",
        "Now let's get started with navigation.",
        "This is the current location input field. Just start typing the room number the dropdown will help you.",
        "The same thing here... Type in the room number you want to go to.",
        "Great!!!. Now click on the checkbox if you want to use the elevator...",
        "Now all that's left to do is toclick on the start button and I will calculate the best path for you!"

    };
    public int currentInstIndex = 0 ;
    void Start()
    {
       if(currentInstIndex == 0 ){
        dialogueScript.message = dialogueList[currentInstIndex];
        dialogueScript.startAnim();
       }
    }

    public void mainInputsRefresh(){
        if(currentInstIndex == 0 ){

        }else if(currentInstIndex == 3){
            character.SetActive(false);
            curLocationinputField.SetActive(true);  
            curDropDown.SetActive(true);
        }else if(currentInstIndex == 4){
            destInputField.SetActive(true);
            destDropDown.SetActive(true);
        }else if (currentInstIndex == 5){
            keyboard.SetActive(false);
            checkBox.SetActive(true);
        }else if (currentInstIndex == 6){
            navButton.SetActive(true);
        }
    }
    
    // Update is called once per frame
    // void Update()
    // {
    //     if(dialogueScript.messageDone = true){
    //         if (Input.GetMouseButtonDown(0))
    //             {
    //                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //                 RaycastHit hit;
    //                 if (Physics.Raycast(ray, out hit))
    //                 {
    //                     if (hit.collider.gameObject == dlBox)
    //                     {
    //                         // The specific object has been clicked, do something
    //                         currentInstIndex++;
    //                         if (currentInstIndex < dialogueList.Count)
    //                         {
    //                             dialogueScript.message = dialogueList[currentInstIndex];
    //                             dialogueScript.startAnim();
    //                         }
    //                     }
    //                 }
    //             }
    //     }
    // }
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    //     if(eventData.pointerCurrentRaycast.gameObject.name == "DialogueText" || eventData.pointerCurrentRaycast.gameObject.name == "Image"){
    //         if(dialogueScript.messageDone = true){
    //             currentInstIndex++;
    //             if (currentInstIndex < dialogueList.Count)
    //             {
    //                 dialogueScript.message = dialogueList[currentInstIndex];
    //                 mainInputsRefresh();
    //                 dialogueScript.startAnim();
    //             }
    //     }
        
    // }
    // }
    }

