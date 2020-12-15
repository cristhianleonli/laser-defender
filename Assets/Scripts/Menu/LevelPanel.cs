using DG.Tweening;
using TMPro;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image startA;
    [SerializeField] private Image startB;
    [SerializeField] private Image startC;
    [SerializeField] private Image lockIcon;

    public delegate void OnTappedEvent(Level level);
    public event OnTappedEvent OnTapped;

    private bool isHovering = false;
    private Level level;

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    public void SetLevel(Level level)
    {
        this.level = level;
        UpdateUI();
    }

    private void OnMouseEnter()
    {
        //if (isHovering) return;

        //isHovering = true;
        //transform.localScale = new Vector3(1.005f, 1.005f, 0);

        //if (level.IsEnabled)
        //{
        //    AudioManager.Instance.PlaySound(SoundType.Hover);
        //}
    }

    private void OnMouseExit()
    {
        //if (isHovering == false) return;

        //isHovering = false;
        //transform.DOScale(1f, 0.05f);
    }

    private void OnMouseOver()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    DOTween.Sequence()
        //            .Append(transform.DOScale(0.99f, 0.05f))
        //            .Append(transform.DOScale(1, 0.1f));

        //    if (level.IsEnabled)
        //    {
        //        AudioManager.Instance.PlaySound(SoundType.OpenLevel);
        //        OnTapped?.Invoke(level);
        //    }
        //    else
        //    {
        //        AudioManager.Instance.PlaySound(SoundType.EmptyClick);
        //    }
        //}
    }

    private void UpdateUI()
    {
        //titleText.text = level.Identifier;
        //lockIcon.gameObject.SetActive(!level.IsEnabled);
        //titleText.gameObject.SetActive(level.IsEnabled);

        //if (level.IsEnabled == false || level.IsPlayed == false)
        //{
        //    startA.gameObject.SetActive(false);
        //    startB.gameObject.SetActive(false);
        //    startC.gameObject.SetActive(false);
        //    return;
        //}

        //Sprite goldStar = ImageLoader.GoldStar;
        //Sprite silverStar = ImageLoader.SilverStar;

        //startA.sprite = silverStar;
        //startB.sprite = silverStar;
        //startC.sprite = silverStar;

        //if (level.starCount == 1)
        //{
        //    startA.sprite = goldStar;
        //}

        //if (level.starCount == 2)
        //{
        //    startB.sprite = goldStar;
        //}

        //if (level.starCount == 3)
        //{
        //    startC.sprite = goldStar;
        //}
    }
}
