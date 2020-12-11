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
        string resourceName = pillType == PillType.Blue ? "pill_blue" : "pill_yellow";
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/PowerUps/" + resourceName);
    }
}
