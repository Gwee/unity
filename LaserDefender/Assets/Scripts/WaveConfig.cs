using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float randomSpawnFactor = 0.3f;

    public List<Transform> getWayPoints() {
        var waveWayPoints = new List<Transform>();
        foreach (Transform wayPoint in pathPrefab.transform)
        {
            waveWayPoints.Add(wayPoint);
        }

        return waveWayPoints;
    }
    public GameObject getEnemyPrefab() { return enemyPrefab; }

    public GameObject getPathPrefab() { return pathPrefab; }

    public int getNumberOfEnemies() { return numberOfEnemies; }

    public float getMoveSpeed() { return moveSpeed; }

    public float getTimeBetweenSpawn() { return timeBetweenSpawn; }

    public float getRandomSpawnFactor() { return randomSpawnFactor; }
}
