using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlinRiceRoomBin : MonoBehaviour
{
    Dictionary<string, GameObject> gameobjectDict = new Dictionary<string, GameObject>();


    // Start is called before the first frame update
    public List<GameObject> container;
    void Start()
    {
        foreach (GameObject gameobject in container) 
        {
            gameobjectDict.Add(gameobject.name, gameobject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
