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


    [SerializeField] private SkinnedMeshRenderer mesh;
    [SerializeField] private Material material;

    [SerializeField] private List<GameObject> deadLootPrefabs;

    public event Action<Enemy> onEnemyCreated;
    public event Action<Enemy, DamageData> onHit;
    public event Action<Enemy> onDie;

    private bool isDead = false;

    public int CurrentHP => enemy.currentHP;
    public int MaxHP => enemyData.maxHP;

    public EnemySpawner enemySpawner;

    private void Awake()
    {
        Material newMaterial = new Material(mesh.material);
        mesh.material = newMaterial;
    }
    void Start()
    {
        enemy = enemyData.CreateEnemy();
        onEnemyCreated?.Invoke(enemy);
    }

    public void GetHit(DamageData damageData)
    {
        if(isDead)
            return;
        enemy.currentHP -= damageData.damage;
        StartCoroutine(VisuallyHurtEnemy());
        onHit?.Invoke(enemy, damageData);

        if (enemy.currentHP <= 0)
        {
            isDead = true;
            enemy.currentHP = 0;
            if(enemySpawner != null)
            {
                enemySpawner.NotifyEnemyDied();
            }
            
            EnemyEventBus.EnemyDied(enemy);
            SpawnDeadLoot();
            Destroy(gameObject,3f);
        }
    }

    private IEnumerator VisuallyHurtEnemy() 
    {
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mesh.material.color = Color.white;
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
        return isDead;
    }
}