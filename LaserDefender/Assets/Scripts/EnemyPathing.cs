using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    private int waypointIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.waypoints = waveConfig.getWayPoints();
        transform.position = waypoints[waypointIdx].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void setWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void Move() {
        if (waypointIdx <= waypoints.Count - 1) {
            var targetPos = waypoints[waypointIdx].transform.position;
            var movementPerFrame = Time.deltaTime * waveConfig.getMoveSpeed();
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementPerFrame);
            if (transform.position == targetPos) {
                waypointIdx++;
            }
        } else {
            Destroy(this.gameObject);
        }

    }
}
