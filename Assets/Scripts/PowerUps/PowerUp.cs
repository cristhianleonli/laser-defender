using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag($"{ObjectTag.Player}"))
        {
            Destroy(this.gameObject);
        }
    }
}
