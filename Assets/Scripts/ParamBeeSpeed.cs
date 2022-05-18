using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamBeeSpeed : ParamSlider
{
    public static float beeSpeed;

    void Start()
    {
        if (beeSpeed == 0) beeSpeed = paramSlider.value;
        else paramSlider.value = beeSpeed;
    }

    void Update()
    {
        beeSpeed = paramSlider.value;
        parameterText.text = beeSpeed.ToString("f2");
    }

    public static float getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return beeSpeed;     ////調整した変数を戻り値にする。
    }
}
