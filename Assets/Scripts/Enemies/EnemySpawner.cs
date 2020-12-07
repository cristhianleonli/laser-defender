using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] private bool looping = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves());
        } while (looping);
    }

    private IEnumerator SpawnWaves() {
        foreach (var wave in waveConfigs)
        {
            yield return StartCoroutine(SpawnEnemiesInWave(wave));
        }
    }

    private IEnumerator SpawnEnemiesInWave(WaveConfig config)
    {
        for (int enemyCount = 0; enemyCount < config.NumberOfEnemies; enemyCount++)
        {
            var enemy = Instantiate(
                config.EnemyPrefab,
                config.GetWaypoints()[0].transform.position,
                Quaternion.identity
            );

            enemy.GetComponent<EnemyPathing>().SetWaveConfig(config);
            yield return new WaitForSeconds(config.TimeBetweenSpawns);
        }
    }
}
