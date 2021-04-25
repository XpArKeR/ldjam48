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
        Debug.Log("Enter");
        ToolTip.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        Hide();
    }

    public void Hide()
    {
        ToolTip.gameObject.SetActive(false);
        Debug.Log("Exiting");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enter");
        ToolTip.gameObject.SetActive(true);
    }
}
