using UnityEngine;
using System.Collections;

/// <summary>
/// A very basic enemy spawner that just randomly picks a prefab in a wave
/// and spawn it
/// </summary>
//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField]
//    private float spawnInterval = 2f;
//    [SerializeField]
//    private float waveDuration = 20f;
//    [SerializeField]
//    private EnemyWave[] enemyWaves;
//    private int waveNumber = 0;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        StartCoroutine(SpawnCoroutine());
//    }

//    private IEnumerator SpawnCoroutine()
//    {
//        float timePassed = 0f;
//        while (true)
//        {
//            yield return new WaitForSeconds(spawnInterval);
//            timePassed += spawnInterval;
//            if(timePassed >= waveDuration)
//            {
//                //If it's already the last wave, just keep spawning a prefab from
//                //this wave
//                if(waveNumber < enemyWaves.Length - 1)
//                {
//                    waveNumber++;
//                }
//                timePassed = 0f;
//            }
//            GameObject enemyPrefab = enemyWaves[waveNumber].GetEnemyPrefab();
//            Instantiate(enemyPrefab);
//            enemyPrefab.transform.position = transform.position;
//        }
//    }
//}

//[System.Serializable]
//public class EnemyWave
//{
//    public GameObject[] enemyPrefabs;
//    public GameObject GetEnemyPrefab()
//    {
//        int r = Random.Range(0, enemyPrefabs.Length);
//        return enemyPrefabs[r];
//    }
//}
