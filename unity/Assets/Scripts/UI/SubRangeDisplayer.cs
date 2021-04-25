using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubRangeDisplayer : MonoBehaviour
{
    public Image fillArea;

    public float min = -1;
    public float max = -1;

    public float rangeMin = -1;
    public float rangeMax = -1;

    // Start is called before the first frame update
    void Start()
    {
        Redraw();
    }


    public void Redraw()
    {
        if (min < 0 || max < 0 || rangeMin < 0 || rangeMax < 0)
        {

            fillArea.rectTransform.anchorMin = new Vector2(0, 0);
            fillArea.rectTransform.anchorMax = new Vector2(0, 1);
            return;
        }

        float diff = (rangeMax - rangeMin);

        float minX = (min - rangeMin);
        float maxX = (max - rangeMin);
        Debug.Log("rangeMin: " + rangeMin);
        Debug.Log("rangeMax: " + rangeMax);
        Debug.Log("minX: " + minX);
        Debug.Log("maxX: " + maxX);
        Debug.Log("diff: " + diff);
        if (diff != 0)
        {
            minX /= diff;
            maxX /= diff;
        }
        Debug.Log("calced minX: " + minX);
        Debug.Log("calced maxX: " + maxX);
        fillArea.rectTransform.anchorMin = new Vector2(minX, 0);
        fillArea.rectTransform.anchorMax = new Vector2(maxX, 1);
    }

   

}
