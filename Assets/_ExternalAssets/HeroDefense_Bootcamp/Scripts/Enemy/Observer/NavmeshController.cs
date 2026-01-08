using System.Threading;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Todo: Finish this class so that when the enemy gets hit with a slow attack,
/// its speed is reduced based on the value of damageData.slowDown, and after
/// damageData.slowDownTime passed, the speed returns to normal. Also when
/// the enemy is killed, it should stop moving. Add new fields and methods if
/// neccessary. 
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class NavmeshController : EnemyObserver
{
    private NavMeshAgent navMeshAgent;


    protected override void OnEnemyCreated(Enemy enemy)
    {
        //todo
        navMeshAgent.speed = enemy.Speed;
    }

    protected override void OnEnemyDie(Enemy enemy)
    {
        navMeshAgent.speed = 0;
    }

    protected override void OnEnemyHit(Enemy enemy, DamageData damageData)
    {
        float counter = 0;
        while (counter < damageData.slowDownTime)
        {
            navMeshAgent.speed = damageData.slowDown;
            counter += Time.deltaTime;
        }
        navMeshAgent.speed = enemy.Speed;
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(Target.targetPosition);
    }
}
