using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamBeeFreq : ParamSlider
{
    public static int beeFreq;

    void Start()
    {
        if (beeFreq == 0) beeFreq = (int)paramSlider.value;
        else paramSlider.value = beeFreq;
    }

    void Update()
    {
        beeFreq = (int)paramSlider.value;
        parameterText.text = beeFreq.ToString();  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。
    }

    public static int getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return beeFreq;     ////調整した変数を戻り値にする。
    }
}
