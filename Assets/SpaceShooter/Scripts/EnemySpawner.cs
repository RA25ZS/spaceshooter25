using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<AssetReference> waveConfigs;
    [SerializeField] bool looping = false;
    int startingWave = 0;

    AssetReference currentWaveRef;
    
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } 
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemies(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemies(AssetReference waveAssetRef)
    {
        if (currentWaveRef != null)
        {
            currentWaveRef.ReleaseAsset();
        }

        WaveConfig waveConfig = waveAssetRef.LoadAssetAsync<WaveConfig>().WaitForCompletion();

        currentWaveRef = waveAssetRef;

        for (int enemyCount = 0; enemyCount < waveConfig.GetNumOfEnemies; enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), 
            waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimwBetweenSpawns);
        }
    }
}
