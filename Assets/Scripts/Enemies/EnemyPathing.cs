using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    private float moveSpeed => waveConfig.MoveSpeed;

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig config)
    {
        waveConfig = config;
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementFrame = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(
                transform.position, targetPosition, movementFrame
            );

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
