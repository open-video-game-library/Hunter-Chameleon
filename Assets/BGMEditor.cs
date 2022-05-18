using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMEditor : MonoBehaviour
{
    private GameObject BGMObj;
    // Start is called before the first frame update
    void Start()
    {
        BGMObj = GameObject.Find("BGM Default");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleValueChanged() 
    {
        if(GetComponent<Toggle>().isOn)
        BGMObj.GetComponent<AudioSource>().enabled = true;
        else
        BGMObj.GetComponent<AudioSource>().enabled = false;
    }
}
