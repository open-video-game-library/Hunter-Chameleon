using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamAppleSize : ParamSlider
{
    // Start is called before the first frame update
    public static float appleSize;

    void Start()
    {
        if (appleSize == 0) appleSize = paramSlider.value;
        else paramSlider.value = appleSize;
    }

    void FixedUpdate()
    {
        appleSize = paramSlider.value;
        parameterText.text = appleSize.ToString("f2");  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。
    }

    public static float getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return appleSize;     ////調整した変数を戻り値にする。
    }
}
