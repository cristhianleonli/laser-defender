using DG.Tweening;
using TMPro;
using Data;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer startA;
    [SerializeField] private SpriteRenderer startB;
    [SerializeField] private SpriteRenderer startC;
    [SerializeField] private SpriteRenderer lockIcon;

    private bool isHovering = false;
    private LevelConfig config;

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    public void SetConfiguration(LevelConfig config)
    {
        this.config = config;
        UpdateUI();
    }

    private void OnMouseEnter()
    {
        if (isHovering) return;

        isHovering = true;
        transform.localScale = new Vector3(1.005f, 1.005f, 0);

        if (!config.isLocked)
        {
            AudioManager.Instance.PlaySound(SoundType.Hover);
        }
    }

    private void OnMouseExit()
    {
        if (isHovering == false) return;
        
        isHovering = false;
        transform.localScale = new Vector3(1f, 1f, 0);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DOTween.Sequence()
                    .Append(transform.DOScale(0.99f, 0.1f))
                    .Append(transform.DOScale(1, 0.1f));

            if (config.isLocked)
            {
                AudioManager.Instance.PlaySound(SoundType.EmptyClick);
            } else
            {
                AudioManager.Instance.PlaySound(SoundType.OpenLevel);
                OpenLevel();
            }
        }
    }

    private void UpdateUI()
    {
        titleText.text = config.Identifier;
        lockIcon.gameObject.SetActive(config.isLocked);
        titleText.gameObject.SetActive(!config.isLocked);

        if (config.isLocked || !config.isPlayed)
        {
            startA.gameObject.SetActive(false);
            startB.gameObject.SetActive(false);
            startC.gameObject.SetActive(false);
            return;
        }

        Sprite goldStar = Resources.Load<Sprite>(Constants.GoldStar);
        Sprite silverStar = Resources.Load<Sprite>(Constants.SilverStar);

        startA.sprite = silverStar;
        startB.sprite = silverStar;
        startC.sprite = silverStar;

        if (config.starCount == 1)
        {
            startA.sprite = goldStar;
        }

        if (config.starCount == 2)
        {
            startB.sprite = goldStar;
        }

        if (config.starCount == 3)
        {
            startC.sprite = goldStar;
        }
    }

    private void OpenLevel()
    {
        FindObjectOfType<MenuController>().OpenLevel(config);
    }
}
