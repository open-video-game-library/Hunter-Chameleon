using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_STANDALONE || UNITY_EDITOR
using Leap;
#endif

namespace Chameleon
{
    public class DummyCursorAim : MonoBehaviour
    {
        // X, Y座標の移動可能範囲
        [System.Serializable]
        public class Bounds
        {
            public float xMin, xMax, yMin, yMax;
        }
        [SerializeField] Bounds bounds;

        float timer;

        float posX, posY;


    #if UNITY_STANDALONE || UNITY_EDITOR
        LeapController leapController;
        Controller controller = new Controller();
    #endif

        private void Start()
        {
    #if UNITY_STANDALONE || UNITY_EDITOR
            leapController = GameObject.Find("LeapController").GetComponent<LeapController>();
    #endif
            gameObject.SetActive(false);
        }

        private void Update()
        {
            timer += Time.deltaTime;
            var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    #if UNITY_STANDALONE || UNITY_EDITOR
            Frame frame = controller.Frame();
            if(frame.Hands.Count != 0)
            {
                //posX = leapController.handPos.x;
                //posY = leapController.handPos.y;
            }
            else
            {
                posX = cursorPos.x;
                posY = cursorPos.y;
            }
    #else
            posX = cursorPos.x;
            posY = cursorPos.y;
    #endif
            posY = posY - 40.0f;
            transform.position = new Vector3(Mathf.Clamp(posX, bounds.xMin, bounds.xMax), Mathf.Clamp(posY, bounds.yMin - 40.0f, bounds.yMax - 40.0f), 120f);
        }
    }
}