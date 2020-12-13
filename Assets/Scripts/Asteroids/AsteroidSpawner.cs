using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid[] asteroidPrefabs;
    [SerializeField] private bool autoStart = true;

    [SerializeField] private float minStartTime = 1f;
    [SerializeField] private float maxStartTime = 1.5f;

    private float spawnInterval => Random.Range(minStartTime, maxStartTime);
    private Asteroid asteroidPrefab => asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length - 1)];

    private Coroutine spawningCoroutine;

    private void Start()
    {
        if (autoStart)
        {
            spawningCoroutine = StartCoroutine(SpawnAsteroids());
        }
    }

    public void ResumeSpawning()
    {
        spawningCoroutine = StartCoroutine(SpawnAsteroids());
    }

    public void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            Asteroid asteroid = Instantiate(asteroidPrefab, transform);

            var isRight = Random.Range(0, 2) == 0 ? true : false;
            float positionX = isRight ? 13 : -13;
            float positionY = Random.Range(-8f, 8f);

            asteroid.transform.position = new Vector3(positionX, positionY, 0);

            var gravity = Random.Range(-0.5f, 0.5f);
            asteroid.ApplyGravity(gravity);

            var velocity = new Vector3(isRight ? Random.Range(-3f, -5f) : Random.Range(3f, 5f), Random.Range(-3f, 3f), 0);
            asteroid.ApplyVelocity(velocity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
