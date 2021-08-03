using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    private int startingWave = 0;
    private bool isWaveDone = false;
    [SerializeField] bool loopingWaves = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (loopingWaves);
        
    }

    // Update is called once per frame
    void Update()
    {
    
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
