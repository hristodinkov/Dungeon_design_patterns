
using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestSpawner : MonoBehaviour
{
    [SerializeField] protected Collider spawnArea;
    [SerializeField] private Inventory inventory;

    [SerializeField]private List<ItemData> swords;
   
    [SerializeField]private List<GameObject> objectsToSpawn;
    
    private void Start()
    {
        
        spawnArea = GetComponent<Collider>();
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
