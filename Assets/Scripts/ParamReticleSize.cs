using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamReticleSize : ParamSlider
{
    public static float reticleSize;
    // Start is called before the first frame update
    void Start()
    {
        if (reticleSize == 0) reticleSize = paramSlider.value;
        else paramSlider.value = reticleSize;
    }

    void Update()
    {
        reticleSize = paramSlider.value;
        parameterText.text = reticleSize.ToString("f2");  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。
    }

    public static float getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return reticleSize;     ////調整した変数を戻り値にする。
    }
}
