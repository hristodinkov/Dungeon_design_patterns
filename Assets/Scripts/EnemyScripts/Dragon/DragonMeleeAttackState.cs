using UnityEngine;

public class DragonMeleeAttackState : State
{
    private float attackDuration = 1.5f;
    private float damageTimeStart = 0.5f;   
    private float damageTimeEnd = 0.8f;     

    private float startTime;
    private bool colliderActive = false;

    private float attackRange => blackboard.attackRange;
    private int damage = 20;

    public DragonMeleeAttackState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        startTime = Time.time;
        colliderActive = false;

        if (blackboard.agent != null)
            blackboard.agent.isStopped = true;

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Attack", true);
            blackboard.animator.SetBool("Chase", false);
            blackboard.animator.SetBool("Idle", false);
        }

        
        if (blackboard.attackCollider != null)
            blackboard.attackCollider.enabled = false;
    }

    public override void Step()
    {
        float elapsed = Time.time - startTime;

        
        if (!colliderActive && elapsed >= damageTimeStart && elapsed <= damageTimeEnd)
        {
            colliderActive = true;
            if (blackboard.attackCollider != null)
                blackboard.attackCollider.enabled = true;
        }

        if (colliderActive && elapsed > damageTimeEnd)
        {
            colliderActive = false;
            if (blackboard.attackCollider != null)
                blackboard.attackCollider.enabled = false;
        }
    }

    public override void Exit()
    {
        base.Exit();

        if (blackboard.animator != null)
            blackboard.animator.SetBool("Attack", false);

        
        if (blackboard.attackCollider != null)
            blackboard.attackCollider.enabled = false;
    }

    public bool AttackFinished()
    {
        return Time.time >= startTime + attackDuration;
    }

    public bool InAttackRange()
    {
        float dist = Vector3.Distance(
            blackboard.enemyTransform.position,
            blackboard.target.position
        );

        return dist <= blackboard.attackRange;
    }
}
