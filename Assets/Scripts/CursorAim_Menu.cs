using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_STANDALONE || UNITY_EDITOR
using Leap;
#endif


public class CursorAim_Menu : MonoBehaviour
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

    float posX, posY;

#if UNITY_STANDALONE || UNITY_EDITOR
    LeapController_Menu leapController;
    Controller controller = new Controller();
#endif

    private void Start()
    {
        CacheJoystickNames = Input.GetJoystickNames();
#if UNITY_STANDALONE || UNITY_EDITOR
        leapController = GameObject.Find("LeapController_Menu").GetComponent<LeapController_Menu>();
#endif
        //Cursor.visible = false;
    }

    private void Update()
    {
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#if UNITY_STANDALONE || UNITY_EDITOR
        Frame frame = controller.Frame();
        if(frame.Hands.Count != 0)
        {
            posX = leapController.handPos.x;
            posY = leapController.handPos.y;
        }
        else
        {
            if(CacheJoystickNames.Length != 0)
            {
                float X = Input.GetAxis("Horizontal")* seisitivity;
                float Y = Input.GetAxis("Vertical")* seisitivity;
                posX += X;
                posY += Y;               
            }
            else
            {                
                posX = cursorPos.x;
                posY = cursorPos.y;
            }
        }
#else
        posX = cursorPos.x;
        posY = cursorPos.y;
#endif
        transform.position = new Vector3(Mathf.Clamp(posX, bounds.xMin, bounds.xMax), Mathf.Clamp(posY, bounds.yMin, bounds.yMax), 1f);
    }
}
