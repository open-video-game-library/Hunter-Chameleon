using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class SettingsButton : MonoBehaviour
{
    GameObject settingsButton;
    GameObject settingsPanel;

    void Start()
    {
        // Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);
        // Debug.Log(Screen.width + ", " + Screen.height);
        
        //settingsPanel.SetActive(false);
        
    }

    void Update()
    {

    }

    public void OnToggleChanged()
    {
        settingsButton = GameObject.Find("Canvas/SettingsButton");
        if(SceneManager.GetActiveScene().name == "EditScene")
        settingsPanel = GameObject.Find("EditCanvas/EdittingPanel");
        else if(SceneManager.GetActiveScene().name == "MenuScene")
        settingsPanel = GameObject.Find("Canvas/SettingsPanel");

        Toggle _settingsButton = settingsButton.GetComponent<Toggle>();
        if (_settingsButton.isOn)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }
}
