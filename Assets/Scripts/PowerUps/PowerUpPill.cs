using UnityEngine;

enum PillType
{
    Blue,
    Yellow
}

public class PowerUpPill : PowerUp
{
    [SerializeField] private PillType pillType;

    private void Start()
    {
        SetupSprite();
    }

    private void SetupSprite()
    {
        Sprite sprite = pillType == PillType.Blue ? ImageLoader.BluePill : ImageLoader.YellowPill;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
