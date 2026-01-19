using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Collider spawnArea;
    [SerializeField] private List<GameObject> enemyPrefabs;
    private bool tooManyEnemies = false;
    [SerializeField]private int enemyCount = 0;
    

    void Start()
    {
        spawnArea = GetComponent<Collider>();
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < 3; i++)
            SpawnEnemy();

        while (true)
        {
            if (enemyCount < 7)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(10f);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void SpawnEnemy() 
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Bounds spawnBounds = spawnArea.bounds;
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            spawnBounds.min.y,
            Random.Range(spawnBounds.min.z, spawnBounds.max.z)
        );
        GameObject enemyObj = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        enemyObj.GetComponent<EnemyController>().enemySpawner = this;
        enemyCount++;
    }
    public void NotifyEnemyDied()
    {
        enemyCount--;
    }


}
