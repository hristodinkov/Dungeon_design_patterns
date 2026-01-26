
using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestSpawner : EnemySpawner
{
    public List<ItemData> swords;
    public Inventory inventory;
    private void Start()
    {
        spawnedEnemies = new List<GameObject>();
        spawnArea = GetComponent<Collider>();
    }

    public void DespawnAllEnemies()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        spawnedEnemies.Clear();
    }

    public void SpawnItem()
    {
        GameObject itemToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        Bounds spawnBounds = spawnArea.bounds;
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnBounds.min.x, spawnBounds.max.x),
            spawnBounds.min.y,
            Random.Range(spawnBounds.min.z, spawnBounds.max.z)
        );
        GameObject item = Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
        
    }

    public void AddRandomSword()
    {
        inventory.AddItem(new Item(swords[Random.Range(0,swords.Count)]));
    }
}
