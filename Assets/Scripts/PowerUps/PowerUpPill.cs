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
        string resourceName = pillType == PillType.Blue ? "pill_blue" : "pill_yellow";
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/PowerUps/" + resourceName);
    }
}
