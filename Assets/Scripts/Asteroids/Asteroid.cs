using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public void StartFlying()
    {
        transform.position = GetRandomPosition();
    }

    public void ApplyGravity(float gravity)
    {
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    public void ApplyVelocity(Vector3 velocity)
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-12, -13);
        float randomY = Random.Range(-8, 8);
        return new Vector3(randomX, randomY, 0);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = ImageLoader.AsteroidExplode;
            transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            StartCoroutine(AutoDestroy());
        }
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
