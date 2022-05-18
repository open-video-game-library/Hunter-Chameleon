#if UNITY_STANDALONE || UNITY_EDITOR

using UnityEngine;
using System.Collections;
using Leap;
using System.Collections.Generic;
using System.Linq;

namespace Chameleon
{
    public class LeapController : MonoBehaviour
    {
        Controller controller = new Controller();

        bool isGrabbed;

        [SerializeField]
        GameObject cursorAim;
        Tongue tongue;

        public Vector2 handPos;

        float sensitivityX, sensitivityY;


        // Use this for initialization
        void Start()
        {
            isGrabbed = false;
            // cursorAim = GameObject.Find("CursorAim");
            //tongue = GameObject.Find("Tongue").GetComponent<Tongue>();

            if (ParamLeapX.getParam() == 0) sensitivityX = 4;
            else sensitivityX = ParamLeapX.getParam();
            if (ParamLeapY.getParam() == 0) sensitivityY = 4;
            else sensitivityY = ParamLeapY.getParam();
        }

        // Update is called once per frame
        void Update()
        {
            Frame frame = controller.Frame();
            if(frame.Hands.Count != 0)
            {
                handPos.x = (frame.Hands[0].PalmPosition.x / 300.0f) * 8.0f;
                handPos.y = ((frame.Hands[0].PalmPosition.y / 500.0f) * 10.0f) - 5.0f;
                handPos.x = handPos.x * sensitivityX;
                handPos.y = handPos.y * sensitivityY;
                // Debug.Log(frame.Hands[0].PalmPosition.x + ", " + frame.Hands[0].PalmPosition.y);
                // Debug.Log(handPosX + ", " + handPosY + ", " + 1f);
                // cursorAim.transform.position = new Vector3(handPosX, handPosY, 1f);
                if ((frame.Fingers.Count(n => n.IsExtended) <= 1) && !isGrabbed)
                {
                    //tongue.Trigger(cursorAim.transform.position);
                    isGrabbed = true;
                }
                if (!(frame.Fingers.Count(n => n.IsExtended) <= 1) && isGrabbed)
                {
                    isGrabbed = false;
                }
            }
        }
    }

    #endif
}