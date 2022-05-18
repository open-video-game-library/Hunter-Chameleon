using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuButton : MonoBehaviour
{
    private GameObject MenuObject;
    private GameObject MainObject;
    void Start()
    {
        /*
        MenuObject = GameObject.Find("MenuObject");
        MenuObject.SetActive(false);
        */
        MainObject = GameObject.Find("MainObject");
    }
    public void OnClickButton()
    {
        SceneManager.LoadScene("MenuScene");
        //Application.LoadLevelAdditive("MenuScene");
        //MenuObject.SetActive(true);
        MainObject.SetActive(false);
    }
}
