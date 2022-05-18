using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamTime : ParamSlider
{
    public static int playtime;

    void Start()
    {
        if (playtime == 0) playtime = (int)paramSlider.value;    ///（0がデフォルト値）
        else paramSlider.value = playtime;           ////既に一回以上値を設定している時
    }

    void FixedUpdate()
    {
        playtime = (int)paramSlider.value;
        parameterText.text = playtime.ToString() + "sec";
    }

    public static int getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return playtime;     ////調整した変数を戻り値にする。
    }
}
