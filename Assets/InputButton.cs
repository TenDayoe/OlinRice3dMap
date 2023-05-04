using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class InputButton : MonoBehaviour
{
    public GameObject OnScreenKeyboard; 
    public GameObject selfButton;
    public List<string> roomList = new List<string>(){"119", "110", "111", "112", "113", "114", "115", "116", "117", "118", "106", "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "104", "189", "162", "163", "164", "152", "100", "154", "159", "156", "109", "188", "171", "102", "108", "187", "165", "144", "173", "150", "146", "103", "140", "197", "158", "183", "184", "185", "186", "172", "174", "170", "107", "175", "149", "101", "141", "142", "143", "145", "147", "148", "182", "178", "177", "176", "181", "180", "198", "179",
"299", "290", "287", "280", "285", "284", "278", "283", "276", "280", "281", "282", "274", "289", "260", "210", "261", "211", "212", "277", "213", "262", "214", "215", "275", "263", "216", "272", "217", "218", "264", "219", "270", "273", "220", "209", "221", "206", "200", "222", "271", "207", "298", "201", "243", "240", "208", "223", "252", "241", "224", "205", "225", "254", "226", "227", "253", "228", "229", "230", "256", "250", "245", "231", "232", "233", "258", "247", "255", "246", "297", "259", "257", "249",
"393", "399", "391", "389", "387", "385", "384", "283", "382", "360", "390", "388", "386", "310", "361", "311", "312", "362", "377", "313", "378", "380", "379", "381", "314", "315", "316", "371", "363", "374", "398", "372", "364", "317", "318", "319", "365", "370", "320", "309", "321", "307", "306", "300", "301", "200", "302", "340", "308", "341", "351", "352", "353", "322", "323", "343", "324", "355", "344", "325", "326", "354", "350", "345", "327", "328", "356", "329", "347", "358", "330", "357", "346", "331", "397", "348", "349"};
    public TMP_Dropdown dropdown;
    void Start(){
        selfButton = this.gameObject;
        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChange(); });
    }


    void OnDropdownValueChange() {
        
        if(dropdown.IsExpanded){
            int selectedIndex = dropdown.value;
            string selectedValue = dropdown.options[selectedIndex].text;
            transform.Find("TextVal").GetComponent<TextMeshProUGUI>().text = selectedValue;
        }
        
    }
    public void selected(){
        selfButton.transform.Find("TextVal").GetComponent<TextMeshProUGUI>().text = "";
        OnScreenKeyboard.SetActive(true);
        if(OnScreenKeyboard.gameObject.transform.GetChild(0).transform.GetComponent<key>().Holder != null){
            OnScreenKeyboard.gameObject.transform.GetChild(0).transform.GetComponent<key>().Holder.transform.Find("arrow").gameObject.SetActive(false);
        }
        foreach(Transform child in OnScreenKeyboard.gameObject.transform){
            child.transform.GetComponent<key>().Holder = this.gameObject;
        }
        this.gameObject.transform.Find("arrow").gameObject.SetActive(true);
    }
    public void InvokeSearch(){ 
        List<string> matches = roomList.Where(item => item.StartsWith(transform.Find("TextVal").GetComponent<TextMeshProUGUI>().text)).ToList();
        dropdown.ClearOptions();
        dropdown.AddOptions(matches);
        dropdown.value = -1;
        
    }
    
}
