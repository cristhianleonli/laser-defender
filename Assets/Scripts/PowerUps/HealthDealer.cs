using UnityEngine;

public class HealthDealer : MonoBehaviour
{
    [SerializeField] int health = 1;

    public int GetHealth()
    {
        return health;
    }
}
