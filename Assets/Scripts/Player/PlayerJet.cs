using DG.Tweening;
using UnityEngine;

public class PlayerJet : MonoBehaviour
{
    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        FadeOut();
    }

    public void FadeOut()
    {
        renderer.DOFade(0, 0.3f);
    }

    public void FadeIn()
    {
        renderer.DOFade(1, 0.3f);
    }
}
