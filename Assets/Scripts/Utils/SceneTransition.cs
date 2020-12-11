using DG.Tweening;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Transform leftPanel;
    [SerializeField] private Transform rightPanel;
    [SerializeField] private SpriteRenderer image;

    private float openLeftPosition = -21f;
    private float openRightPosition = 21f;
    private float closeLeftPosition = -7.85f;
    private float closeRightPosition = 7.85f;
    private float smallerScale = 0.97f;

    private float animationDuration = 0.5f;

    public delegate void OnTransitionOut();

    private void Start()
    {
        // hide by default
        //gameObject.SetActive(false);
    }

    // When the transition is closed and side panels move away
    public void TransitionIn(Transform content)
    {
        //leftPanel.position = new Vector3(closeLeftPosition, 0, 0);
        //rightPanel.position = new Vector3(closeRightPosition, 0, 0);
        content.localScale = new Vector3(smallerScale, smallerScale, smallerScale);

        // preparation
        //gameObject.SetActive(true);

        // actual move
        //leftPanel.DOMoveX(openLeftPosition, animationDuration).SetEase(Ease.InCubic);
        //rightPanel.DOMoveX(openRightPosition, animationDuration).SetEase(Ease.InCubic);
        content.DOScale(1f, animationDuration).SetEase(Ease.InQuint);

        // center image
        //image.transform.DOScale(6f, animationDuration).SetEase(Ease.InQuint);
        image.DOFade(0, animationDuration * 2);
        //image.transform.DORotate(new Vector3(0, 0, 90), animationDuration);
    }

    public void TransitionOut(Transform content, OnTransitionOut callback)
    {
        // panels
        //leftPanel.DOMoveX(closeLeftPosition, animationDuration).SetEase(Ease.InCubic);
        //rightPanel.DOMoveX(closeRightPosition, animationDuration).SetEase(Ease.InCubic);

        //// image
        //image.transform.DOScale(3f, animationDuration).SetEase(Ease.InQuint);
        //image.DOFade(1, animationDuration);
        //image.transform.DORotate(new Vector3(0, 0, 0), animationDuration);
        image.DOFade(0, animationDuration);
        content.DOScale(smallerScale, animationDuration)
            .SetEase(Ease.InQuint)
            .OnComplete(() => callback.Invoke());
    }
}
