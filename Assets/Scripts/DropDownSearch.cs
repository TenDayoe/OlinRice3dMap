using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DropDownSearch: MonoBehaviour
{
    public TMP_InputField searchField;
    public TMP_Dropdown resultsDropdown;

   


    private List<string> roomNumbers;

    //private ManageRooms manageRooms;

    void Start()
    {

        roomNumbers = GetAllRoomNumbers();

        // Add an event listener to the search field to update the dropdown menu as the user types
        searchField.onValueChanged.AddListener(delegate { OnSearchTextChanged(); });

        resultsDropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        // // Add an event listener to the search field to reattach the OnValueChanged listener when the user finishes editing the field
        // searchField.onEndEdit.AddListener(delegate { searchField.onValueChanged.AddListener(delegate { OnSearchTextChanged(); }); });
    }


    void OnDropdownValueChanged()
    {
        // Set the text of the TMP same as the text of the element in the drop down that was clicked. 
        searchField.text = resultsDropdown.options[resultsDropdown.value].text;
    }

    public void OnSearchTextChanged()
    {
        // Get the current text in the search field
        string searchText = searchField.text;

        
        
        // Filter the list of room numbers to only include those that start with the search text
        List<string> filteredRoomNumbers = roomNumbers.Where(rn => rn.StartsWith(searchText)).ToList();

        // Clear the drop-down menu and add the filtered room numbers as new options
        resultsDropdown.ClearOptions();
        resultsDropdown.AddOptions(filteredRoomNumbers);
        
        // Show the drop-down menu
        resultsDropdown.enabled = false;
        resultsDropdown.enabled = true;

        resultsDropdown.Show();
        searchField.ActivateInputField();
        searchField.caretPosition = 2;    
        
    }

    /// <summary>
    /// Returns a list of room numbers extracted from JSON file
    /// </summary>
    List<string> GetAllRoomNumbers()
    {
       List<string> temp = new List<string>();
       temp.Add("101");
       temp.Add("102");
       temp.Add("103");
       return temp;
    }

    /// <summary>
    /// Check if a room number is valid (ie, having exactly 3 digits)
    /// 4 digit room numbers are used to represent doorways/entrances, which should not be considered
    /// </summary>
    bool RoomNumberIsValid(string number) {
        return number.Length == 3;
    }
}
