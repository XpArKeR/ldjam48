using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SliderExtensions
{
    public static void SetMinMax(this Slider slider, float minValue = 0, float maxValue = 1)
    {
        if (slider != default)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
        }
    }
}
