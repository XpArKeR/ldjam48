using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomResouceBar : MonoBehaviour
{

    public Color barColor;
    public Image currentBar;
    public Image possibleChangeBar;

    private float min;
    private float range;
    private float currentValue;
    private float currentRelative;


    void Start()
    {
        currentBar.color = barColor;
        Color possibleChangeColor = new Color(barColor.r, barColor.g, barColor.b, 0.7f);
        possibleChangeBar.color = possibleChangeColor;
        possibleChangeBar.gameObject.SetActive(false);
    }

    public void SetCurrentValue(float current)
    {
        currentValue = current;
        currentRelative = (current - min) / range;
        Vector2 vector = new Vector2(currentRelative, 1);
        currentBar.rectTransform.anchorMax = vector;
    }

    public void ClearPossibleChange()
    {
        Vector2 vector = new Vector2(currentRelative, 1);
        currentBar.rectTransform.anchorMax = vector;
        possibleChangeBar.gameObject.SetActive(false);
    }

    public void SetPossibleChange(float possibleChange)
    {
        if (possibleChange < 0)
        {
            float consumptionRelative = (-possibleChange - min) / range;           
            float consumptionRelativeMin = currentRelative - consumptionRelative;
            if (consumptionRelativeMin < 0)
            {
                consumptionRelativeMin = 0;
            }
            SetBarsForPossibleChanges(consumptionRelativeMin, currentRelative);
        }
        else
        {
            float consumptionRelative = (possibleChange - min) / range;           
            float consumptionRelativeMax = currentRelative + consumptionRelative;
            if (consumptionRelativeMax > 1)
            {
                consumptionRelativeMax = 1;
            }
            SetBarsForPossibleChanges(currentRelative, consumptionRelativeMax);
        }
        possibleChangeBar.gameObject.SetActive(true);
    }

    private void SetBarsForPossibleChanges(float consumptionRelativeMin, float consumptionRelativeMax)
    {
        Vector2 vectorTempMax = new Vector2(consumptionRelativeMin, 1);
        currentBar.rectTransform.anchorMax = vectorTempMax;
        Vector2 vectorMin = new Vector2(consumptionRelativeMin, 0);
        possibleChangeBar.rectTransform.anchorMin = vectorMin;
        Vector2 vectorMax = new Vector2(consumptionRelativeMax, 1);
        possibleChangeBar.rectTransform.anchorMax = vectorMax;
    }

    public void SetMinMax(float min, float max)
    {
        this.min = min;
        range = max - min;
    }

    public float GetCurrentValue()
    {
        return currentValue;
    }
}
