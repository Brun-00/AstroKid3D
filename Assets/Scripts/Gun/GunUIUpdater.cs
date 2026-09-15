using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GunUIUpdater : MonoBehaviour
{
    public Image uiImage;

    public float duration = .1f;
    public Ease ease = Ease.OutBack;

    private Tween _currentTween;

    private void OnValidate()
    {
        if (uiImage == null)
        {
            uiImage = GetComponent<Image>();
        }
    }

    // Update the UI fill directly.
    public void UpdateValue(float f)
    {
        uiImage.fillAmount = f;
    }

    // Animate the UI fill based on the remaining shots.
    public void UpdateValue(float max, float current)
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
        }

        uiImage.DOFillAmount(1 - (current / max), duration).SetEase(ease);
    }

    // Show the infinite bullets state.
    public void ShowInfinite()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
        }

        uiImage.fillAmount = 1f;
        uiImage.color = Color.yellow;
    }

    // Restore the normal gun UI.
    public void ShowNormal()
    {
        uiImage.color = Color.green;
    }
}