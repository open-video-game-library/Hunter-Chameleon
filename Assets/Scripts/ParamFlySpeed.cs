using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamFlySpeed : ParamSlider
{
    public static float flySpeed;

    void Start()
    {
        if (flySpeed == 0) flySpeed = paramSlider.value;
        else paramSlider.value = flySpeed;
    }

    void Update()
    {
        flySpeed = paramSlider.value;
        parameterText.text = flySpeed.ToString("f2");
    }

    public static float getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return flySpeed;     ////調整した変数を戻り値にする。
    }
}
