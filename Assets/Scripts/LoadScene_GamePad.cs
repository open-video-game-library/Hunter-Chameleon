using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;

#if UNITY_STANDALONE || UNITY_EDITOR
using Leap;
#endif

namespace Chameleon
{
    public class LoadScene_GamePad : MonoBehaviour
    {
        private string[] CacheJoystickNames;
        private Text startText;
        private Frame frame;
        
        // Start is called before the first frame update
        void Start()
        {
            #if UNITY_STANDALONE || UNITY_EDITOR
            LeapController leapController;
            Controller controller = new Controller();
            #endif

            startText = GameObject.Find("PressAText").GetComponent<Text>();
            CacheJoystickNames = Input.GetJoystickNames();
            frame = controller.Frame();
            if(CacheJoystickNames.Length != 0)
            {
                GameObject.Find("PressAText").SetActive(true);
                startText.text = "Press A to start !";
            }
            else
            {
                GameObject.Find("PressAText").SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(CacheJoystickNames.Length != 0)
            {
                if(Input.GetMouseButtonDown(0)||Input.GetKeyDown("joystick button 1"))
                {
                    SceneManager.LoadScene("MainScene");
                }
            }
            
            if(frame.Hands.Count != 0)
            {
                Debug.Log("2");
                GameObject.Find("PressAText").SetActive(true);
                startText.text = "Close your hand to start !";

                if (frame.Fingers.Count(n => n.IsExtended) <= 1)
                {
                    SceneManager.LoadScene("MainScene");                
                }
                
            }
        }
    }
}