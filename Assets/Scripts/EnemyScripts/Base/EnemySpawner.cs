using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected Collider spawnArea;
    [SerializeField] private List<EnemyController> enemyPrefabs;

    [SerializeField] private bool preWarmSpawn = true;
    [SerializeField] private bool testSpawner = false;
    [HideInInspector]
    private List<EnemyController> spawnedEnemies;

    void Start()
    {
        spawnArea = GetComponent<Collider>();
        spawnedEnemies = new List<EnemyController>();
        if (preWarmSpawn)
            SpawnRoutine();
    }
    private void OnEnable()
    {
        EnemyEventBus.OnEnemyDied += CheckForSpawningAnEnemy;
    }
    private void OnDisable()
    {
        EnemyEventBus.OnEnemyDied -= CheckForSpawningAnEnemy;
    }

    private void CheckForSpawningAnEnemy(EnemyController enemyController)
    {
        if (testSpawner == true)
            return;
        StartCoroutine(LateSpawn(enemyController));
    }

    private IEnumerator LateSpawn(EnemyController enemyController)
    {
        yield return new WaitForSeconds(4f);
        if (spawnedEnemies.Contains(enemyController))
        {
            spawnedEnemies.Remove(enemyController);
            SpawnEnemy();
        }
    }

    private void SpawnRoutine()
    {
        for (int i = 0; i < 5; i++)
            SpawnEnemy();
    }
    public void DespawnAllEnemies()
    {
        foreach (EnemyController enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy.gameObject);
            }
        }
        spawnedEnemies.Clear();
    }
    public void SpawnEnemy() 
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)].gameObject;
        Bounds spawnBounds = spawnArea.bounds;
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            spawnBounds.min.y,
            Random.Range(spawnBounds.min.z, spawnBounds.max.z)
        );
        EnemyController enemyObj = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity).GetComponent<EnemyController>();

        spawnedEnemies.Add(enemyObj);
    }

}
