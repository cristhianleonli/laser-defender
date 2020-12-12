using System.Collections;
using DG.Tweening;
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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = ImageLoader.AsteroidExplode;
            transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            AudioManager.Instance.PlaySound(SoundType.AsteroidExplode);
            StartCoroutine(AutoDestroy());
        }
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
