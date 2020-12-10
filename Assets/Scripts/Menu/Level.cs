using DG.Tweening;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer startA;
    [SerializeField] private SpriteRenderer startB;
    [SerializeField] private SpriteRenderer startC;

    private bool isBigger = false;

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    private void OnMouseEnter()
    {
        if (isBigger == false)
        {
            isBigger = true;
            AudioManager.Instance.PlayHover();
            transform.localScale = new Vector3(1.005f, 1.005f, 0);
        }
    }

    private void OnMouseExit()
    {
        if (isBigger)
        {
            isBigger = false;
            transform.localScale = new Vector3(1f, 1f, 0);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){

            DOTween.Sequence()
                .Append(transform.DOScale(0.99f, 0.1f))
                .Append(transform.DOScale(1, 0.1f));

            AudioManager.Instance.PlayClick();
        }
    }
}
