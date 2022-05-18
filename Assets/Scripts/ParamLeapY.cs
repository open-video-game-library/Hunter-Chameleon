using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamLeapY : ParamSlider
{
    public static float leapY;

    void Start()
    {
        if (leapY == 0) leapY = paramSlider.value;
        else paramSlider.value = leapY;
    }

    void Update()
    {
        leapY = paramSlider.value;
        parameterText.text = leapY.ToString("f2");
    }

    public static float getParam()
    {
        return leapY;
    }
}
