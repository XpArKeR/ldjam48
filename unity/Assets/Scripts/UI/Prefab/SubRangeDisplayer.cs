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
        if (diff != 0)
        {
            minX /= diff;
            maxX /= diff;
        }

        if (minX < 0)
        {
          //  Debug.Log("minX < 0");
           // Debug.Log(string.Format("minX: {0}; maxX: {1}; rangeMin: {2}; rangeMax: {3}; diff: {4}", minX, maxX, rangeMin, rangeMax, diff));
            minX = 0;
        }
        if (maxX > 1)
        {
           // Debug.Log("maxX > 0");
           // Debug.Log(string.Format("minX: {0}; maxX: {1}; rangeMin: {2}; rangeMax: {3}; diff: {4}", minX, maxX, rangeMin, rangeMax, diff));
            maxX = 1;
        }
        if (minX == maxX)
        {
             Debug.Log("minX == maxX");
             Debug.Log(string.Format("minX: {0}; maxX: {1}; rangeMin: {2}; rangeMax: {3}; diff: {4}", minX, maxX, rangeMin, rangeMax, diff));
        }
        if (minX > maxX)
        {
            Debug.Log("minX == maxX");
            Debug.Log(string.Format("minX: {0}; maxX: {1}; rangeMin: {2}; rangeMax: {3}; diff: {4}", minX, maxX, rangeMin, rangeMax, diff));
        }
        fillArea.rectTransform.anchorMin = new Vector2(minX, 0);
        fillArea.rectTransform.anchorMax = new Vector2(maxX, 1);
    }

   

}
