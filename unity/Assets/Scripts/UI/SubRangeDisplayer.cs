using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubRangeDisplayer : MonoBehaviour
{
    public Image fillArea;

    public float min = 2;
    public float max = 4;

    public float rangeMin = 1;
    public float rangeMax = 5;

    // Start is called before the first frame update
    void Start()
    {
        Redraw();
    }


    public void Redraw()
    {
        float diff = (rangeMax - rangeMin);
        float minX = (min - rangeMin) / diff;
        float maxX = (max - rangeMin) / diff;
        fillArea.rectTransform.anchorMin = new Vector2(minX, 0);
        fillArea.rectTransform.anchorMax = new Vector2(maxX, 1);
    }

   

}
