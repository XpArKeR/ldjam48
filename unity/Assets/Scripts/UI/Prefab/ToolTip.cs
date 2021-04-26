using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public GameObject ToolTipObject;

    private void Start()
    {
        ToolTipObject.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        Show();
    }

    public void Show()
    {
        ToolTipObject.gameObject.SetActive(true);
    }

    public void Hide()
    {
        ToolTipObject.gameObject.SetActive(false);
    }
}

