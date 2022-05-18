using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chameleon
{
    public class HpBar : MonoBehaviour
    {
      public Slider hpbar;
      void Start () 
      {
        hpbar = GameObject.Find("Hp Bar").GetComponent<Slider>();
      }

      void Update () 
      {
        var chameleon = Chameleon.instance;
        var hp = chameleon.hp;
        var hpMax = chameleon.hpMax;
        hpbar.value = (float)hp / (float)hpMax;
      }
}
}

