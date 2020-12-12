using DG.Tweening;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject image;

    private float smallerScale = 0.97f;
    private float animationDuration = 0.5f;

    public delegate void OnTransitionOut();

    public void TransitionIn(Transform content)
    {
        image.SetActive(true);
        content.localScale = new Vector3(smallerScale, smallerScale, smallerScale);
        content.DOScale(1f, animationDuration).SetEase(Ease.InQuint);
        image.GetComponent<SpriteRenderer>().DOFade(0, animationDuration * 2);
    }

    public void TransitionOut(Transform content, OnTransitionOut callback)
    {
        image.GetComponent<SpriteRenderer>().DOFade(0, animationDuration);
        content.DOScale(smallerScale, animationDuration)
            .SetEase(Ease.InQuint)
            .OnComplete(() => callback.Invoke());
    }
}
