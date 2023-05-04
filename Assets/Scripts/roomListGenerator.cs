using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class roomListGenerator : MonoBehaviour
{
    public GameObject floor1Rooms; 
    public GameObject floor2Rooms;
    public GameObject floor3Rooms;
    public List<string> allChildNames= new List<string>();
    // Start is called before the first frame update
    void Start()
    {

        GameObject[] floors = {floor1Rooms, floor2Rooms, floor3Rooms};

        foreach (GameObject floor in floors)
        {
            if (floor != null)
            {
                foreach (Transform child in floor.transform)
                {
                    allChildNames.Add(child.gameObject.name); // Add the name of each child to the list
                }
            }
            else
            {
                Debug.LogWarning("Floor object not assigned!");
            }
        }

        string filePath = Application.dataPath + "/rL.csv"; // Path to the file where the CSV will be saved

        // Write the room names to the CSV file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string roomName in allChildNames)
            {
                writer.WriteLine(roomName);
            }
        }

   
}}
