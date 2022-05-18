using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chameleon
{
    public class Chameleon : MonoBehaviour
    {
        public static Chameleon instance;
        public int hpMax; // HP の最大値
        public int hp; // HP

        SpriteRenderer _renderer;

        [SerializeField]
        public Sprite[] SPR_LIST;

        public GameObject panel;
        TimeKeeper tk;
        void Awake()
        {
            hp = hpMax;
            instance = this;
        }

        void Start()
        {
            panel = GameObject.Find("InGameCanvas/Panel");
            _renderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            _renderer.sprite = SPR_LIST[hp];
        }

        void LateUpdate()
        {
        }

        public void Damage()
        {
            hp -= 1;
            if (hp <= 0)
            {
                hp = 0;
                tk = panel.GetComponent<TimeKeeper>();
                tk.Finish();
            }
        }
    }

}
