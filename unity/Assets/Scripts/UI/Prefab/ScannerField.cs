using System;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class ScannerField : MonoBehaviour
{
    private float anchorY;

    private float changeAmount;
    private Action onCompleteAction;
    private Int32 currentItteration;

    public Int32 HalfIterations;
    public Boolean IsMovingDownwards;
    public Image ScanBar;
    public float Thickness;
    public AudioSource AudioSource;

       void Start()
    {
        if (IsMovingDownwards)
        {
            anchorY = 1;
        }
        else
        {
            anchorY = 0;
        }

        this.Thickness /= 2;

        this.changeAmount = CalculateChange();
    }

    void Update()
    {
        var amountToMoveBy = changeAmount * Time.deltaTime;

        if (currentItteration >= HalfIterations)
        {
            this.gameObject.SetActive(false);
            onCompleteAction.Invoke();
        }
        
        if (IsMovingDownwards)
        {
            anchorY -= amountToMoveBy;

            if (anchorY < 0f)
            {
                IsMovingDownwards = !IsMovingDownwards;
                currentItteration++;
            }
        }
        else
        {
            anchorY += amountToMoveBy;

            if (anchorY > 1f)
            {
                IsMovingDownwards = !IsMovingDownwards;
                currentItteration++;
            }
        }

        ScanBar.rectTransform.anchorMin = new Vector2(0, anchorY - Thickness);
        ScanBar.rectTransform.anchorMax = new Vector2(1, anchorY + Thickness);
    }

    public void Scan(Action onCompleteAction)
    {
        if (!this.gameObject.activeSelf)
        {
            this.onCompleteAction = onCompleteAction;
            this.currentItteration = 0;

            if (Core.GameState.Options.AreAnimationsEnabled)
            {
                this.gameObject.SetActive(true);
                this.AudioSource.Play();
            }
            else
            {
                onCompleteAction();
            }
        }
    }

    private float CalculateChange()
    {
        var relativeChange = 0f;

        if (this.transform is RectTransform rectTransform)
        {
            var changePerSecond = (rectTransform.rect.height * HalfIterations) / this.AudioSource.clip.length;

            relativeChange = (1f / rectTransform.rect.height) * changePerSecond;
        }

        return relativeChange;
    }
}
