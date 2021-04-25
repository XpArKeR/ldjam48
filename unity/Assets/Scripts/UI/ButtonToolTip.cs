using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToolTip : MonoBehaviour
{
    public GameObject ToolTip;

    private void Start()
    {
        ToolTip.gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        Show();
    }

    public void Show()
    {
        ToolTip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        ToolTip.gameObject.SetActive(false);
    }
}

