
using UnityEngine;

public class ToolTipButton : MonoBehaviour
{
    public GameObject ToolTip;

    public void OnPointerEnter()
    {
        this.ShowToolTip();
    }

    public void OnPointerExit()
    {
        this.HideToolTip();
    }

    public void OnButtonClick()
    {
        this.HideToolTip();
    }

    private void ShowToolTip()
    {
        if (this.ToolTip != default)
        {
            this.ToolTip.SetActive(true);
        }
    }

    private void HideToolTip()
    {
        if (this.ToolTip != default)
        {
            this.ToolTip.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
