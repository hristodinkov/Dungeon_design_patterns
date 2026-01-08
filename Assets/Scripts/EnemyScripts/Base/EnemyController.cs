using UnityEngine;
using System;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField]
    private EnemyData enemyData;
    private Enemy enemy;

    [SerializeField] private List<GameObject> deadLootPrefabs;

    public event Action<Enemy> onEnemyCreated;
    public event Action<Enemy, DamageData> onHit;
    public event Action<Enemy> onDie;

    void Start()
    {
        enemy = enemyData.CreateEnemy();
        onEnemyCreated?.Invoke(enemy);
    }

    public void GetHit(DamageData damageData)
    {
        enemy.currentHP -= damageData.damage;
        if (enemy.currentHP < 0)
        {
            enemy.currentHP = 0;
            onDie?.Invoke(enemy);
            SpawnDeadLoot();
        }

        onHit?.Invoke(enemy, damageData);
    }

    private void SpawnDeadLoot()
    {
        int r = UnityEngine.Random.Range(0, deadLootPrefabs.Count);
        GameObject deadLoot =
            Instantiate(
                deadLootPrefabs[r],
                new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z),
                Quaternion.identity
            );
    }

    public void GetHitButton()
    {
        DamageData damageData= new DamageData(5);
        enemy.currentHP -= damageData.damage;
        if (enemy.currentHP < 0)
        {
            enemy.currentHP = 0;

        }

        onHit?.Invoke(enemy, damageData);
    }

    public bool IsDead()
    {
        return enemy.currentHP <= 0;
    }
}