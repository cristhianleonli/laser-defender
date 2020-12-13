using DG.Tweening;
using TMPro;
using UnityEngine;

public class StartOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;

    public void SetTitle(string text)
    {
        titleText.text = text;
        titleText.alpha = 1;
    }

    public Tween FadeOutText()
    {
        return titleText.DOFade(0, 1f);
    }

    public void FadeOut()
    {
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
    }
}
