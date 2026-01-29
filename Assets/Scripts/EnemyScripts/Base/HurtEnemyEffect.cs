using System.Collections;
using UnityEngine;

public class HurtEnemyEffect : EnemyObserver
{
    [SerializeField] private SkinnedMeshRenderer mesh;
    [SerializeField] private Material material;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        Material newMaterial = new Material(mesh.material);
        mesh.material = newMaterial;
    }
    protected override void OnEnemyCreated(Enemy enemy)
    {
        // No implementation needed for now
    }

    protected override void OnEnemyDie(Enemy enemy)
    {
        // No implementation needed for now
    }

    protected override void OnEnemyHit(Enemy enemy, DamageData damageData)
    {
        StartCoroutine(VisuallyHurtEnemy());
    }

    private IEnumerator VisuallyHurtEnemy()
    {
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        mesh.material.color = Color.white;
    }
}
