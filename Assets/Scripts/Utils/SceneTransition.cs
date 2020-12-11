using DG.Tweening;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Transform leftPanel;
    [SerializeField] private Transform rightPanel;

    private float openLeftPosition = -21f;
    private float closeLeftPosition = -7.85f;

    private float openRightPosition = 21f;
    private float closeRightPosition = 7.85f;

    private float animationDuration = 0.5f;

    public delegate void OnTransitionOut();

    private void Start()
    {
        // hide by default
        //gameObject.SetActive(false);
    }

    public void TransitionIn(Transform content)
    {
        leftPanel.position = new Vector3(closeLeftPosition, 0, 0);
        rightPanel.position = new Vector3(closeRightPosition, 0, 0);
        content.localScale = new Vector3(0.9f, 0.9f, 0.9f);

        // preparation
        gameObject.SetActive(true);

        // actual move
        leftPanel.DOMoveX(openLeftPosition, animationDuration).SetEase(Ease.InCubic);
        rightPanel.DOMoveX(openRightPosition, animationDuration).SetEase(Ease.InCubic);
        content.DOScale(1f, animationDuration).SetEase(Ease.InQuint);
    }

    public void TransitionOut(Transform content, OnTransitionOut callback)
    {
        leftPanel.DOMoveX(closeLeftPosition, animationDuration).SetEase(Ease.InCubic);
        rightPanel.DOMoveX(closeRightPosition, animationDuration).SetEase(Ease.InCubic);

        content.DOScale(0.9f, animationDuration)
            .SetEase(Ease.InQuint)
            .OnComplete(() => callback.Invoke());
    }
}
