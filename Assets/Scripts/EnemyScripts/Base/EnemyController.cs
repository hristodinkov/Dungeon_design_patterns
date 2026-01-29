using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField]
    private EnemyData enemyData;
    private Enemy enemy;

    [SerializeField] private List<GameObject> deadLootPrefabs;

    public event Action<Enemy> onEnemyCreated;
    public event Action<Enemy, DamageData> onHit;

    public Enemy Enemy => enemy;
    public EnemyData EnemyData => enemyData;
    public int CurrentHP => enemy.currentHP;
    public int MaxHP => enemyData.maxHP;
    public bool IsDead => CurrentHP <= 0;

    public EnemySpawner enemySpawner;

    void Start()
    {
        enemy = enemyData.CreateEnemy();
        onEnemyCreated?.Invoke(enemy);
    }

    public void ApplyHit(DamageData damageData)
    {
        if ( IsDead ) return;

        enemy.currentHP -= damageData.damage;
        onHit?.Invoke(enemy, damageData);

        if (enemy.currentHP <= 0)
        {
            enemy.currentHP = 0;
            
            EnemyEventBus.EnemyDied(this);
            SpawnLootAfterDead();
            Destroy(gameObject,3f);
        }
    }
    private void SpawnLootAfterDead()
    {
        int r = UnityEngine.Random.Range(0, deadLootPrefabs.Count);
        GameObject deadLoot =
            Instantiate(
                deadLootPrefabs[r],
                new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z),
                Quaternion.identity
            );
    }

    private void OnDestroy()
    {
        
    }
}