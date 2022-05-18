using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReticleManager : MonoBehaviour
{
    private Button reticleButton00;
    private Button reticleButton01;
    private Button reticleButton02;
    private Button reticleButton03;
    private Button redButton;
    private Button greenButton;
    private Button blueButton;
    private Button yellowButton;
    private Button mizuiroButton;
    private Button pinkButton;
    private Button orangeButton;
    private GameObject reticleObj;
    private Slider reticleSizeSlider;
    private string redparameter;
    private string greenparameter;
    private string blueparameter;
    int r;
    public static string ReticleName;
    public static string ReticleColor;
    // Start is called before the first frame update
    void Start()
    {
        reticleButton00 = GameObject.Find("ReticleButton00").GetComponent<Button>();
        reticleButton01 = GameObject.Find("ReticleButton01").GetComponent<Button>();
        reticleButton02 = GameObject.Find("ReticleButton02").GetComponent<Button>();
        reticleButton03 = GameObject.Find("ReticleButton03").GetComponent<Button>();
        reticleButton00.onClick.AddListener(SetreticleButton00);
        reticleButton01.onClick.AddListener(SetreticleButton01);
        reticleButton02.onClick.AddListener(SetreticleButton02);
        reticleButton03.onClick.AddListener(SetreticleButton03);
        redButton = GameObject.Find("redbutton").GetComponent<Button>();
        greenButton = GameObject.Find("greenbutton").GetComponent<Button>();
        blueButton = GameObject.Find("bluebutton").GetComponent<Button>();
        yellowButton = GameObject.Find("yellowbutton").GetComponent<Button>();
        mizuiroButton = GameObject.Find("mizuirobutton").GetComponent<Button>();
        pinkButton = GameObject.Find("pinkbutton").GetComponent<Button>();
        orangeButton = GameObject.Find("orangebutton").GetComponent<Button>();

        redButton.onClick.AddListener(redButtonPressed);
        greenButton.onClick.AddListener(greenButtonPressed);
        blueButton.onClick.AddListener(blueButtonPressed);
        yellowButton.onClick.AddListener(yellowButtonPressed);
        mizuiroButton.onClick.AddListener(mizuiroButtonPressed);
        pinkButton.onClick.AddListener(pinkButtonPressed);
        orangeButton.onClick.AddListener(orangeButtonPressed);
        reticleObj = GameObject.Find("CursorAim");
        reticleSizeSlider = GameObject.Find("ParamReticleSize").GetComponent<Slider>();
        //redparameter = GameObject.Find("red_para").GetComponent<Text>().text;
        //greenparameter = GameObject.Find("green_para").GetComponent<Text>().text;
        //blueparameter = GameObject.Find("blue_para").GetComponent<Text>().text;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reticleObj.transform.localScale = Vector3.one * reticleSizeSlider.value;

    /*
        //if(redparameter.text != null && greenparameter.text != null && blueparameter.text != null)
        //reticleObj.GetComponent<SpriteRenderer>().color = new Color32 ((byte)(redparameter.text),(byte)((int)greenparameter.text),(byte)(blueparameter.text),(byte)255);
        if(redparameter != null && greenparameter != null && blueparameter != null)
        {
    
        //r = int.Parse(redparameter);
        r = int.Parse("redparameter");
        var g = int.Parse(greenparameter);
        var b = int.Parse(blueparameter);
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32 ((byte)r,(byte)g,(byte)b,255);
        }
        */


        
    }
    

    
    void SetreticleButton00()
    {
        reticleObj.GetComponent<SpriteRenderer>().sprite = reticleButton00.GetComponent<Image>().sprite;
        ReticleName = "ReticleButton00";
    }
    void SetreticleButton01()
    {
        reticleObj.GetComponent<SpriteRenderer>().sprite = reticleButton01.GetComponent<Image>().sprite;
        ReticleName = "ReticleButton01";
    }
    void SetreticleButton02()
    {
        reticleObj.GetComponent<SpriteRenderer>().sprite = reticleButton02.GetComponent<Image>().sprite;
        ReticleName = "ReticleButton02";
    }
    void SetreticleButton03()
    {
        reticleObj.GetComponent<SpriteRenderer>().sprite = reticleButton03.GetComponent<Image>().sprite;
        ReticleName = "ReticleButton03";
    }

    void redButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(255,0,0,255);
        ReticleColor = "red";
    }
    void greenButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(0,255,0,255);
        ReticleColor = "green";
    }
    void blueButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(0,0,255,255);
        ReticleColor = "blue";
    }
    void yellowButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(255,255,0,255);
        ReticleColor = "yellow";
    }
    void mizuiroButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(0,255,255,255);
        ReticleColor = "mizuiro";
    }
    void pinkButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(255,0,255,255);
        ReticleColor = "pink";
    }
    void orangeButtonPressed()
    {
        reticleObj.GetComponent<SpriteRenderer>().color = new Color32(255,108,0,255);
        ReticleColor = "orange";
    }

    public static string GetReticleName()
    {
        return ReticleName;
    }
    
    public static string GetReticleColor()
    {
        return ReticleColor;
    }
    
}
