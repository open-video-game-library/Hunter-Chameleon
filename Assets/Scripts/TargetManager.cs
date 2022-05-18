using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

namespace Chameleon
{
    public class TargetManager : MonoBehaviour
    {
        public Fly flyPrefab;
        public Apple applePrefab;
        public Bee beePrefab;
        
        int flyInterval, appleInterval, beeInterval;
        private float flyTimer, appleTimer, beeTimer;
        private Button playbutton;
        public bool Playnow = false;
        private Text playbuttontext;
        public bool playmode;
        private Button loadButton;
        private GameObject editobj;
        public Sprite playSprite;
        public Sprite pauseSprite;
        private GameObject ingameCanvas;
        
        void Start()
        {
            if (ParamAppleFreq.getParam() == 0) appleInterval = 5;
            else appleInterval = ParamAppleFreq.getParam();
            if (ParamBeeFreq.getParam() == 0) beeInterval = 8;
            else beeInterval = ParamBeeFreq.getParam();
            if (ParamFlyFreq.getParam() == 0) flyInterval = 2;
            else flyInterval = ParamFlyFreq.getParam();
            if(SceneManager.GetActiveScene().name == "EditScene")
            {
                playbutton = GameObject.Find("PlayButton").GetComponent<Button>();
                playbutton.onClick.AddListener(ModeChange);
                //playbuttontext = GameObject.Find("PlayButtonText").GetComponent<Text>();
                loadButton = GameObject.Find("PlayButton").GetComponent<Button>();
                loadButton.onClick.AddListener(LoadSettings);
                editobj = GameObject.Find("EdittingPanel");
                ingameCanvas = GameObject.Find("IngameCanvas");
                
            }
            
        }

        void FixedUpdate()
        {
            if(SceneManager.GetActiveScene().name == "MainScene")
            { 
                playmode = true;
                Playnow =true;
            }else
            { 
                
                playmode = false;
            }
        }
        

        void Update()
        {
            if(Playnow)
            {
                flyTimer += Time.deltaTime;
                appleTimer += Time.deltaTime;
                beeTimer += Time.deltaTime;
            }
            
            
            if (flyTimer > flyInterval)
            {
                Instantiate(flyPrefab).Init();
                flyTimer = 0;
            }
            if (appleTimer > appleInterval)
            {
                Instantiate(applePrefab).Init();
                appleTimer = 0;
            }
            if (beeTimer > beeInterval)
            {
                Instantiate(beePrefab).Init();
                beeTimer = 0;
            }
        }

        private void ModeChange()
        {
            if(Playnow)
            {
                GameObject.Find("PlayButton").GetComponent<Image>().sprite = playSprite;
                GameObject.Find("LoadButton").GetComponent<Image>().enabled =true;
                //playbuttontext.text = "Play";
                Playnow = false;
                editobj.SetActive(true);
                ingameCanvas.SetActive(false);
            }
            else
            {
                GameObject.Find("PlayButton").GetComponent<Image>().sprite = pauseSprite;
                GameObject.Find("LoadButton").GetComponent<Image>().enabled =false;
                ///playbuttontext.text = "Pause";
                Playnow = true;
                editobj.SetActive(false);
                ingameCanvas.SetActive(true);
            }
            
        }

        private void LoadSettings()
        {
            if (ParamAppleFreq.getParam() == 0) appleInterval = 5;
            else appleInterval = ParamAppleFreq.getParam();
            if (ParamBeeFreq.getParam() == 0) beeInterval = 8;
            else beeInterval = ParamBeeFreq.getParam();
            if (ParamFlyFreq.getParam() == 0) flyInterval = 2;
            else flyInterval = ParamFlyFreq.getParam();
        }
    }

}
