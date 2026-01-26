using UnityEngine;

public class EnemyTestSpawner : EnemySpawner
{
    private void Start()
    {
        spawnArea = GetComponent<Collider>();
        SpawnEnemy();
    }
}
