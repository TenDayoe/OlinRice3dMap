using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;
public class DropDownSearch: MonoBehaviour
{
    public TMP_InputField searchField;
    public TMP_Dropdown resultsDropdown;

   


    public List<string> roomNumbers;

    //private ManageRooms manageRooms;
    public void openAndroidKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        Invoke("hideInputField", 0.1f);
    }
    private void hideInputField()
    {
        TouchScreenKeyboard.hideInput = true;
    }
    void Start()
    {

        GetAllRoomNumbers();
        
        // Add an event listener to the search field to update the dropdown menu as the user types
        searchField.onValueChanged.AddListener(delegate { OnSearchTextChanged(); });

        resultsDropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        // // Add an event listener to the search field to reattach the OnValueChanged listener when the user finishes editing the field
        // searchField.onEndEdit.AddListener(delegate { searchField.onValueChanged.AddListener(delegate { OnSearchTextChanged(); }); });
    }


    void OnDropdownValueChanged()
    {
        
        searchField.text = resultsDropdown.options[resultsDropdown.value].text;
    }

    public void OnSearchTextChanged()
    {
        // Get the current text in the search field
        string searchText = "OL" +searchField.text;

        
        
        // Filter the list of room numbers to only include those that start with the search text
        List<string> filteredRoomNumbers = roomNumbers.Where(rn => rn.StartsWith(searchText)).ToList();
        filteredRoomNumbers.Insert(0,"Choose room : ");

        // Clear the drop-down menu and add the filtered room numbers as new options
        resultsDropdown.ClearOptions();
        resultsDropdown.AddOptions(filteredRoomNumbers);
        
        // Show the drop-down menu
        // resultsDropdown.enabled = false;
        // resultsDropdown.enabled = true;

        resultsDropdown.Show();
        searchField.ActivateInputField();
        searchField.caretPosition = 2;    
        
    }

    /// <summary>
    /// Returns a list of room numbers extracted from JSON file
    /// </summary>
    void GetAllRoomNumbers()
    {
        List<string> allChildNames = new List<string>();
        allChildNames.Add("Choose room : ");
       string filePath = Application.dataPath + "/roomList.csv"; // Path to the CSV file

        if (File.Exists(filePath)) // Check if the file exists
        {
            StreamReader reader = new StreamReader(filePath);

            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(','); // Split the line by commas

                allChildNames.Add(line[0]); // Add the first element of the line (which is the child name) to the list
            }

            reader.Close(); // Close the reader
        }
        else
        {
            Debug.LogWarning("CSV file not found!");
        }
        roomNumbers = allChildNames;
    
    }

    /// <summary>
    /// Check if a room number is valid (ie, having exactly 3 digits)
    /// 4 digit room numbers are used to represent doorways/entrances, which should not be considered
    /// </summary>
    bool RoomNumberIsValid(string number) {
        return number.Length == 3;
    }
}
