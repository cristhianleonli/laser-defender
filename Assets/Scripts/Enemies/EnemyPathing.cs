using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] WaveConfig waveConfig;
    private List<Transform> waypoints;
    private float moveSpeed => waveConfig.MoveSpeed;

    private int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
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
