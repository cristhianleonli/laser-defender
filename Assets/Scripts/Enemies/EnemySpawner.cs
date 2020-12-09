using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool isLooping = true;

    [SerializeField] List<WaveConfig> waveConfigs;

    IEnumerator Start()
    {
        // FIXME: remove
        waveConfigs.Clear();

        do
        {
            yield return StartCoroutine(SpawnWaves());
        } while (isLooping);
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
