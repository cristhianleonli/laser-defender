using DG.Tweening;
using TMPro;
using Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image startA;
    [SerializeField] private Image startB;
    [SerializeField] private Image startC;
    [SerializeField] private Image lockIcon;

    private Button buttonComponent;

    public delegate void OnTappedEvent(Level level);
    public event OnTappedEvent OnTapped;

    private bool isHovering = false;
    private Level level;

    private void Start()
    {
        buttonComponent = GetComponent<Button>();

        buttonComponent.onClick.AddListener(OnpanelTapped);
    }

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    public void SetLevel(Level level)
    {
        this.level = level;
        UpdateUI();
    }

    private void OnpanelTapped()
    {
        DOTween.Sequence()
                .Append(transform.DOScale(0.9f, 0.1f))
                .Append(transform.DOScale(1, 0.05f));

        if (level.IsEnabled)
        {
            AudioManager.Instance.PlaySound(SoundType.OpenLevel);
            OnTapped?.Invoke(level);
        }
        else
        {
            AudioManager.Instance.PlaySound(SoundType.EmptyClick);
        }
    }

    private void UpdateUI()
    {
        titleText.text = level.Identifier;
        lockIcon.gameObject.SetActive(!level.IsEnabled);
        titleText.gameObject.SetActive(level.IsEnabled);

        if (level.IsEnabled == false)
        {
            startA.gameObject.SetActive(false);
            startB.gameObject.SetActive(false);
            startC.gameObject.SetActive(false);
            return;
        }

        Sprite goldStar = ImageLoader.GoldStar;
        Sprite silverStar = ImageLoader.SilverStar;

        startA.sprite = silverStar;
        startB.sprite = silverStar;
        startC.sprite = silverStar;

        if (level.starCount == 1)
        {
            startA.sprite = goldStar;
        }

        if (level.starCount == 2)
        {
            startB.sprite = goldStar;
        }

        if (level.starCount == 3)
        {
            startC.sprite = goldStar;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHovering) return;

        isHovering = true;
        transform.localScale = new Vector3(1.05f, 1.05f, 0);

        if (level.IsEnabled)
        {
            AudioManager.Instance.PlaySound(SoundType.Hover);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHovering == false) return;

        isHovering = false;
        transform.DOScale(1f, 0.1f);
    }
}
