using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public void StopFlying()
    {
        Destroy(this.gameObject);
    }
}
