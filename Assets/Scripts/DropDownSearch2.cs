using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;
public class DropDownSearch2: MonoBehaviour
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
        // Set the text of the TMP same as the text of the element in the drop down that was clicked. 
        searchField.text = resultsDropdown.options[resultsDropdown.value].text;
    }

    public void OnSearchTextChanged()
    {
        // Get the current text in the search field
        string searchText = "" +searchField.text;

        
        
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
    void GetAllRoomNumbers()
    {
        List<string> allChildNames = new List<string>();
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
        // roomNumbers = new List<string>(){"100", "101", "102", "103", "104", "106", "107", "108", "109", 
        // "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127"
        // , "128", "129", "130", "131", "132", "140", "141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "152", 
        // "154", "156", "158", "159", "162", "163", "164", "165", "170", "171", "172", "173", "174", "175", "176", "177", "178", 
        // "179", "180", "181", "182", "183", "184", "185", "186", "187", "188", "189", "197", "198", "200", "201", "205", "206", 
        // "207", "208", "209", "210", "211", "212", "213", "214", "215", "216", "217", "218", "219", "220", "221", "222", "223", 
        // "224", "225", "226", "227", "228", "229", "230", "231", "232", "233", "240", "241", "243", "245", "246", "247", "249", 
        // "250", "252", "253", "254", "255", "256", "257", "258", "259", "260", "261", "262", "263", "264", "270", "271", "272", 
        // "273", "274", "275", "276", "277", "278", "280", "280", "281", "282", "283", "284", "285", "287", "289", "290", "297", 
        // "298", "299", "200", "283", "300", "301", "302", "306", "307", "308", "309", "310", "311", "312", "313", "314", "315", 
        // "316", "317", "318", "319", "320", "321", "322", "323", "324", "325", "326", "327", "328", "329", "330", "331", "340", 
        // "341", "343", "344", "345", "346", "347", "348", "349", "350", "351", "352", "353", "354", "355", "356", "357", "358", 
        // "360", "361", "362", "363", "364", "365", "370", "371", "372", "374", "377", "378", "379", "380", "381", "382", "384", 
        // "385", "386", "387", "388", "389", "390", "391", "393", "397", "398", "399"};
    }

    /// <summary>
    /// Check if a room number is valid (ie, having exactly 3 digits)
    /// 4 digit room numbers are used to represent doorways/entrances, which should not be considered
    /// </summary>
    bool RoomNumberIsValid(string number) {
        return number.Length == 3;
    }
}
