using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerConfig
{
    public float minSpawnerFactor = 1;
    public float maxSpawnerFactor = 1.5f;

    public SpawnerConfig(float minSpawnerFactor, float maxSpawnerFactor)
    {
        this.minSpawnerFactor = minSpawnerFactor;
        this.maxSpawnerFactor = maxSpawnerFactor;
    }
}

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid[] asteroidPrefabs;
    [SerializeField] private bool autoStart = true;

    #region Spawner config
    private SpawnerConfig spawnerConfig;
    private float minStartTime => (spawnerConfig == null) ? 1f : spawnerConfig.minSpawnerFactor;
    private float maxStartTime => (spawnerConfig == null) ? 1.5f : spawnerConfig.maxSpawnerFactor;
    #endregion

    private Coroutine spawningCoroutine;
    private Asteroid asteroidPrefab => asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length - 1)];
    private float spawnInterval => Random.Range(minStartTime, maxStartTime);

    private void Start()
    {
        if (autoStart)
        {
            spawningCoroutine = StartCoroutine(SpawnAsteroids());
        }
    }

    public void SetConfiguration(SpawnerConfig spawnerConfig)
    {
        this.spawnerConfig = spawnerConfig;
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
