using System.Collections;
using Constants;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public void ApplyGravity(float gravity)
    {
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    public void ApplyVelocity(Vector3 velocity)
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != Layers.Shredder)
        {
            Explode();
        }
    }

    private void Explode()
    {
        GetComponent<SpriteRenderer>().sprite = ImageLoader.AsteroidExplode;
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        AudioManager.Instance.PlaySound(SoundType.AsteroidExplode);
        StartCoroutine(AutoDestroy());
    }
}