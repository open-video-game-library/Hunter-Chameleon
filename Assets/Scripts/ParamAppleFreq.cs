using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamAppleFreq : ParamSlider
{
    public static int appleFreq;

    void Start()
    {
        if (appleFreq == 0) appleFreq = (int)paramSlider.value;
        else paramSlider.value = appleFreq;
    }

    void Update()
    {
        appleFreq = (int)paramSlider.value;
        parameterText.text = appleFreq.ToString();  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。
    }

    public static int getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return appleFreq;     ////調整した変数を戻り値にする。
    }
}
