using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image starA;
    [SerializeField] private Image starB;
    [SerializeField] private Image starC;

    public void FadeOut()
    {
        gameObject.SetActive(false);
    }

    public void FadeIn(int starCount)
    {
        starA.DOFade(0, 0);
        starB.DOFade(0, 0);
        starC.DOFade(0, 0);

        // deactive stars
        starA.gameObject.SetActive(false);
        starB.gameObject.SetActive(false);
        starC.gameObject.SetActive(false);

        // activate self
        gameObject.SetActive(true);

        if (starCount >= 1)
        {
            AnimateStar(starA, 0);
        }

        if (starCount >= 2)
        {
            AnimateStar(starB, 1);
        }

        if (starCount >= 3)
        {
            AnimateStar(starC, 2);
        }
    }

    private void AnimateStar(Image star, float delayFactor)
    {
        float animationDuration = 0.7f;
        star.gameObject.SetActive(true);

        DOTween.Sequence()
            .SetDelay(animationDuration * delayFactor)
            .Append(star.DOFade(1, animationDuration))
            .Append(star.gameObject.transform.DOScale(1.05f, 0.5f))
            .Append(star.gameObject.transform.DOScale(1f, 0.1f));
    }
}
