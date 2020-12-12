using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageLoader
{
    public static Sprite GoldStar => Resources.Load<Sprite>("Sprites/UI/star_gold");
    public static Sprite SilverStar => Resources.Load<Sprite>("Sprites/UI/star_silver");
    public static Sprite BluePill => Resources.Load<Sprite>("Sprites/PowerUps/pill_blue");
    public static Sprite YellowPill => Resources.Load<Sprite>("Sprites/PowerUps/pill_yellow");
    public static Sprite AsteroidExplode => Resources.Load<Sprite>("Sprites/Asteroids/spaceEffects_012");
}