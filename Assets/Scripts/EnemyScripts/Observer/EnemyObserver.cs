using UnityEngine;

public abstract class EnemyObserver : MonoBehaviour
{
    [SerializeField]
    protected EnemyController enemyController;
    protected void OnEnable()
    {
        enemyController.onEnemyCreated += OnEnemyCreated;
        enemyController.onHit += OnEnemyHit;
        enemyController.onDie += OnEnemyDie;
    }

    protected void OnDisable()
    {
        enemyController.onEnemyCreated -= OnEnemyCreated;
        enemyController.onHit -= OnEnemyHit;
        enemyController.onDie -= OnEnemyDie;
    }

    protected abstract void OnEnemyCreated(Enemy enemy);

    protected abstract void OnEnemyHit(Enemy enemy, DamageData damageData);

    protected abstract void OnEnemyDie(Enemy enemy);

}
