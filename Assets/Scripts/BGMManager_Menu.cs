using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon
{
    public class BGMManager_Manu : MonoBehaviour
    {
        [SerializeField]
        private AudioSource[] _bgms;

        /// <summary>
        /// BGMの混ぜ具合。0ならSound1、1ならSound2になる
        /// </summary>
        [Range(0, 1)]
        public float _mixRate = 0;

        public GameObject panel;
        private TimeKeeper tk;

        void Start()
        {
            panel = GameObject.Find("Canvas/Panel");
        }

        public void Play()
        {
            _bgms[0].Play();
            _bgms[1].Play();
        }

        private void Update()
        {
            _bgms[0].volume = (1f - _mixRate) * 0.1f;
            _bgms[1].volume = (_mixRate) * 0.1f;
            tk = panel.GetComponent<TimeKeeper>();
            if (tk.skyNum >= 2)
            {
                _mixRate += 0.005f;
                if (_mixRate >= 1)
                {
                    _mixRate = 1;
                }
            }
        }

        public void PlayEd()
        {
            _bgms[0].Stop();
            _bgms[1].Stop();
            _bgms[2].volume = 0.1f;
            _bgms[2].Play();
        }
    }
}