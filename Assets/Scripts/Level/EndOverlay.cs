using TMPro;
using UnityEngine;

public class EndOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;

    public void FadeOut()
    {
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
    }
}
