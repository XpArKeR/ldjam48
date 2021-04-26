using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextSize : MonoBehaviour
{
    public Text text;
    void Start()
    {
        int fontSize = Screen.height / 20;
        text.fontSize = fontSize;
    }


}
