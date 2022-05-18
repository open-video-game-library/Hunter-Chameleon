using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamSlider : MonoBehaviour
{
    public GameObject sliderObj;             /////スライダオブジェクト

    [System.NonSerialized]
    public Slider paramSlider;
    // public static int playtime;     //////スライダで調整する数値。staticにすることで別シーンに変数を共有できる
    public GameObject parameterTextObj;     ////スライダUIの下に表示させるパラメーター

    [System.NonSerialized]
    public Text parameterText;

    [SerializeField]
    private AudioSource sliderSound;

    float preParamNum;

    void Awake()
    {
        paramSlider = sliderObj.GetComponent<Slider>();
        parameterText = parameterTextObj.GetComponent<Text>();
    }

    void Update()
    {

        if (preParamNum != paramSlider.value)
        {
            sliderSound.Play();
        }
        preParamNum = paramSlider.value;
    }

    // void Update()
    // {
    //     playtime = (int)paramSlider.value;
    //     parameterText.text = playtime.ToString();  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。
    // }

    // public static int getParam()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    // {
    //     return playtime;     ////調整した変数を戻り値にする。
    // }
}
