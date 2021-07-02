using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    private int startingWave = 0;
    private bool isWaveDone = false;

    // Start is called before the first frame update
    void Start()
    {
        // var currentWaveConfig = waveConfigs[startingWave];
        StartCoroutine(SpawnAllWaves());
        // foreach(WaveConfig waveConfig in this.waveConfigs) {
            // StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
            // startingWave++;
        // isWaveDone = true;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // var currentWaveConfig = waveConfigs[startingWave];
        // if (isWaveDone) {
        //     StartCoroutine(SpawnAllEnemiesInWave(currentWaveConfig));
        // }
    }

    private IEnumerator SpawnAllWaves() {
        foreach(WaveConfig waveConfig in this.waveConfigs) {
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {

        for (int i = 0; i < waveConfig.getNumberOfEnemies(); i++) 
        {
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(),
                waveConfig.getWayPoints()[0].transform.position,
                Quaternion.identity);
            
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawn());
        }


    }
}
