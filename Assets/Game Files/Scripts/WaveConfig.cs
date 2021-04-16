using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float spawnRandom;
    [SerializeField] int numOfEnemies;
    [SerializeField] float moveSpeed;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimwBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandom()
    {
        return spawnRandom;
    }

    public int GetNumOfEnemies()
    {
        return numOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
