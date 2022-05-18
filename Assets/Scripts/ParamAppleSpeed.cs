using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamAppleSpeed : ParamSlider
{
    public static float appleSpeed;

    void Start()
    {
        if (appleSpeed == 0) appleSpeed = paramSlider.value;
        else paramSlider.value = appleSpeed;
    }

    void Update()
    {
        appleSpeed = paramSlider.value;
        parameterText.text = appleSpeed.ToString("f2") + "(GravityScale)";
    }

    public static float getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return appleSpeed;     ////調整した変数を戻り値にする。
    }
}
