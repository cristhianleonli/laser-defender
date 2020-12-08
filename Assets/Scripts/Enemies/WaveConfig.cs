using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] public GameObject PathPrefab;
    [SerializeField] public float TimeBetweenSpawns = 0.5f;
    [SerializeField] public float SpawnRandomFactor = 0.3f;
    [SerializeField] public float MoveSpeed = 5f;
    [SerializeField] public int NumberOfEnemies = 10;

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in PathPrefab.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
