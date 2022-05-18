using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamLeapX : ParamSlider
{
    public static float leapX;

    void Start()
    {
        if (leapX == 0) leapX = paramSlider.value;
        else paramSlider.value = leapX;
    }

    void Update()
    {
        leapX = paramSlider.value;
        parameterText.text = leapX.ToString("f2");
    }

    public static float getParam()
    {
        return leapX;
    }
}
