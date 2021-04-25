using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubRangeDisplayer : MonoBehaviour
{
    public Image fillArea;

    public float min;
    public float max;

    public float rangeMin;
    public float rangeMax;

    // Start is called before the first frame update
    void Start()
    {
        Redraw();
    }


    public void Redraw()
    {

        //fillArea.rectTransform.anchorMin.x = 
    }

    private float CalcValue()
    {
        //return (rangeMax - )
        return 0f;
    }

}
