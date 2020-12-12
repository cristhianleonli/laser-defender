using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid[] asteroidPrefabs;
    
    private float minStartTime = 1f;
    private float maxStartTime = 3f;

    private float spawnInterval => Random.Range(minStartTime, maxStartTime);
    private Asteroid asteroidPrefab => asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length - 1)];

    private void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            Asteroid asteroid = Instantiate(asteroidPrefab, transform);
            asteroid.StartFlying();

            var gravity = Random.Range(0, 1);
            asteroid.ApplyGravity(gravity);

            var velocity = new Vector3(Random.Range(5, 5), Random.Range(1, 2), 0);
            asteroid.ApplyVelocity(velocity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
