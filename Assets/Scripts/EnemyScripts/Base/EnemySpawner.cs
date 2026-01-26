
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected Collider spawnArea;
    [SerializeField] protected List<GameObject> objectsToSpawn;
    private bool tooManyEnemies = false;
    [SerializeField]private int enemyCount = 0;

    [HideInInspector]
    protected List<GameObject> spawnedEnemies;

    void Start()
    {
        spawnArea = GetComponent<Collider>();
        spawnedEnemies = new List<GameObject>();
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

    public void SpawnEnemy() 
    {
        GameObject enemyToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        Bounds spawnBounds = spawnArea.bounds;
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            spawnBounds.min.y,
            Random.Range(spawnBounds.min.z, spawnBounds.max.z)
        );
        GameObject enemyObj = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        enemyObj.GetComponent<EnemyController>().enemySpawner = this;
        enemyCount++;
        spawnedEnemies.Add(enemyObj);
    }
    public void NotifyEnemyDied()
    {
        enemyCount--;
    }


}
