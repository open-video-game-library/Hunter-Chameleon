using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


#if UNITY_STANDALONE || UNITY_EDITOR
using Leap;
#endif

namespace Chameleon
{
    public class CursorAim : MonoBehaviour
    {
        private string[] CacheJoystickNames;
        [SerializeField]public float seisitivity = 0.25f;
        // X, Y座標の移動可能範囲
        [System.Serializable]
        public class Bounds
        {
            public float xMin, xMax, yMin, yMax;
        }
        [SerializeField] Bounds bounds;

        [System.NonSerialized]
        public GameObject _tongue;

        float timer;
        public Sprite[] ReticleSprite;
        float posX, posY;
        public TargetManager targetManager;
        //public Text a;

    #if UNITY_STANDALONE || UNITY_EDITOR
        LeapController leapController;
        Controller controller = new Controller();
    #endif

        private void Start()
        {
            
            CacheJoystickNames = Input.GetJoystickNames();
            Debug.Log(CacheJoystickNames.Length);
            //Reticle Sprite
            if (ReticleManager.GetReticleName() == null || ReticleManager.GetReticleName() == "ReticleButton00")           
                GetComponent<SpriteRenderer>().sprite = ReticleSprite[0];             
            else if(ReticleManager.GetReticleName() == "ReticleButton01")             
                GetComponent<SpriteRenderer>().sprite = ReticleSprite[1];                 
            else if(ReticleManager.GetReticleName() == "ReticleButton02")          
                GetComponent<SpriteRenderer>().sprite = ReticleSprite[2];                 
            else if(ReticleManager.GetReticleName() == "ReticleButton03")        
                GetComponent<SpriteRenderer>().sprite = ReticleSprite[3];
            //Reticle Size
            if (ParamReticleSize.getParam() == 0) this.transform.localScale = Vector3.one;
            else this.transform.localScale = ParamReticleSize.getParam() *  Vector3.one;
            //Reticle Color
            if (ReticleManager.GetReticleColor() == null || ReticleManager.GetReticleColor() == "pink")           
                GetComponent<SpriteRenderer>().color = new Color32(255,0,255,255);             
            else if(ReticleManager.GetReticleColor() == "red")             
                GetComponent<SpriteRenderer>().color = new Color32(255,0,0,255); 
            else if(ReticleManager.GetReticleColor() == "green")             
                GetComponent<SpriteRenderer>().color = new Color32(0,255,0,255);     
            else if(ReticleManager.GetReticleColor() == "blue")             
                GetComponent<SpriteRenderer>().color = new Color32(0,0,255,255);             
            else if(ReticleManager.GetReticleColor() == "yellow")          
                GetComponent<SpriteRenderer>().color = new Color32(255,255,0,255);                 
            else if(ReticleManager.GetReticleColor() == "mizuiro")        
                GetComponent<SpriteRenderer>().color = new Color32(24,235,249,255);   
            else if(ReticleManager.GetReticleColor() == "orange")             
                GetComponent<SpriteRenderer>().color = new Color32(255,108,0,255);  

            

    #if UNITY_STANDALONE_OSX || UNITY_EDITOR
            leapController = GameObject.Find("LeapController").GetComponent<LeapController>();
    #endif
            _tongue = GameObject.Find("Tongue");
            Cursor.visible = false;
        }
        

        private void Update()
        {
            timer += Time.deltaTime;
            var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posX = cursorPos.x;
            posY = cursorPos.y;
            //a.text="Update";
            /*
    #if UNITY_STANDALONE_OSX || UNITY_EDITOR
            Frame frame = controller.Frame();
            if(frame.Hands.Count != 0)
            {
                posX = leapController.handPos.x;
                posY = leapController.handPos.y;
                Debug.Log("B");
                a.text="p1";
            }
            else
            {
                if(CacheJoystickNames.Length != 0)
                {
                    float X = Input.GetAxis("Horizontal")* seisitivity;
                    float Y = Input.GetAxis("Vretical")* seisitivity;
                    posX += X;
                    posY += Y;
                    a.text="p2";
                }
                else
                {
                    a.text="p3";
                    posX = cursorPos.x;
                    posY = cursorPos.y;
                }
                    
                        
                
            }
    #else
            a.text="elze";
            posX = cursorPos.x;
            posY = cursorPos.y;
    #endif
    */

            
            if(SceneManager.GetActiveScene().name == "EditScene" &&!targetManager.Playnow)
            {
                bounds.yMin = -4.6f;
            }
            else
            {
                bounds.yMin = -2.8f;
            }

            transform.position = new Vector3(Mathf.Clamp(posX, bounds.xMin, bounds.xMax), Mathf.Clamp(posY, bounds.yMin, bounds.yMax), 1f);
            
            //transform.position +=  new Vector3(posX * seisitivity,posY * seisitivity,0);
            
            
            var tongue = _tongue.GetComponent<Tongue>();
            if ((Input.GetMouseButtonDown(0)||Input.GetKeyDown("joystick button 1")) && timer > 1)
            {
                Vector3 temp = transform.position;
                temp.z = 0;
                tongue.Trigger(temp);
                //tongue.RayCast(temp);
                // Debug.Log("cursor aim pos: " + transform.position);
            }
            
        
            

            // 舌のリーチ確認
            // tongue.Test(transform.position);
        }
    }

}
