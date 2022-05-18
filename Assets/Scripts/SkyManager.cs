using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon
{
    public class SkyManager : MonoBehaviour
    {

        public Material[] sky;

        public GameObject panel;
        private TimeKeeper tk;

        void start()
        {
        // panel = GameObject.Find("Canvas/Panel");
        }

        void Update()
        {

            // if (Input.GetMouseButtonDown(0))
            // {
            //     num += 1;
            // }
            // if (num >= sky.Length)
            // {
            //     num = 0;
            // }

            tk = panel.GetComponent<TimeKeeper>();
            RenderSettings.skybox = sky[tk.skyNum];
        }
    }
}