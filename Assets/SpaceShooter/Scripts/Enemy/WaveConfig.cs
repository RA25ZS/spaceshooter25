using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
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

        public float GetTimwBetweenSpawns { get => timeBetweenSpawns; }
        public float GetSpawnRandom { get => spawnRandom; }

        public int GetNumOfEnemies { get => numOfEnemies; }
        public float GetMoveSpeed { get => moveSpeed; }
    }
}

