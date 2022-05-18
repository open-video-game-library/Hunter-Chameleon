using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI
;
public class ONOFFManager : MonoBehaviour
{
    private Toggle scoreToggle;
    private GameObject scoreText;
    private Button loadButton;
    private Toggle BGMToggle;

    // Start is called before the first frame update
    void Start()
    {
        scoreToggle = GameObject.Find("ScoreDisplay").GetComponent<Toggle>();
        scoreText = GameObject.Find("ScoreText");
        loadButton = GameObject.Find("PlayButton").GetComponent<Button>();
        loadButton.onClick.AddListener(Activate);
        BGMToggle = GameObject.Find("BGMToggle").GetComponent<Toggle>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        if(scoreToggle.isOn) scoreText.SetActive(true);
        else scoreText.SetActive(false);


    }

    
}
