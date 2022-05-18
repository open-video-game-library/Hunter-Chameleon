using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamFlyFreq : ParamSlider
{
    public static int flyFreq;

    void Start()
    {
        if (flyFreq == 0) flyFreq = (int)paramSlider.value;
        else paramSlider.value = flyFreq;
    }

    void Update()
    {
        flyFreq = (int)paramSlider.value;
        parameterText.text = flyFreq.ToString();  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。
    }

    public static int getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return flyFreq;     ////調整した変数を戻り値にする。
    }
}
