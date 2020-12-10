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
        if (isHovering == false)
        {
            isHovering = true;
            AudioManager.Instance.PlayHover();
            transform.localScale = new Vector3(1.005f, 1.005f, 0);
        }
    }

    private void OnMouseExit()
    {
        if (isHovering)
        {
            isHovering = false;
            transform.localScale = new Vector3(1f, 1f, 0);
        }
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
                AudioManager.Instance.PlayClick();
            } else
            {
                AudioManager.Instance.PlayOpenLevel();
                OpenLevel();
            }
        }
    }

    private void UpdateUI()
    {
        titleText.text = config.Identifier;
        lockIcon.gameObject.SetActive(config.isLocked);
        titleText.gameObject.SetActive(!config.isLocked);

        var starsShouldBeVisible = !config.isLocked;
        startA.gameObject.SetActive(starsShouldBeVisible);
        startB.gameObject.SetActive(starsShouldBeVisible);
        startC.gameObject.SetActive(starsShouldBeVisible);
    }

    private void OpenLevel()
    {
        // TODO: open the specific level
    }
}
