using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset textJson;

    
    // Start is called before the first frame update
    void Start()
    {
        JsonUtility.FromJson<Memory>(textJson.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
