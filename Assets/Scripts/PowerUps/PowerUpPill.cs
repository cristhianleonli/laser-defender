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
        string resourceName = pillType == PillType.Blue ? Constants.BluePill : Constants.YellowPill;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(resourceName);
    }
}
