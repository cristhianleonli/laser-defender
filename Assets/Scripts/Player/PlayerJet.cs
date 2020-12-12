using DG.Tweening;
using UnityEngine;

public class PlayerJet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        FadeOut();
    }

    public void FadeOut()
    {
        spriteRenderer.DOFade(0, 0.3f);
    }

    public void FadeIn()
    {
        spriteRenderer.DOFade(1, 0.3f);
    }
}
