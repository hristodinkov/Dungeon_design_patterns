using UnityEngine;

public class AttackState : State
{
    private float attackStartTime;
    private bool colliderActivated;
    private float colliderDelay = 0.4f;

    public AttackState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();

        blackboard.agent.isStopped = true;

        attackStartTime = Time.time;
        colliderActivated = false;

       
        if (blackboard.attackCollider != null)
            blackboard.attackCollider.enabled = false;

 
        if (blackboard.animator != null)
            blackboard.animator.SetBool("Attack", true);

        blackboard.lastAttackTime = Time.time;
    }

    public override void Step()
    {
        base.Step();

        float elapsed = Time.time - attackStartTime;

    
        if (!colliderActivated && elapsed >= colliderDelay)
        {
            colliderActivated = true;

            if (blackboard.attackCollider != null)
                blackboard.attackCollider.enabled = true;
        }
    }

    public override void Exit()
    {
        base.Exit();

       
        if (blackboard.attackCollider != null)
            blackboard.attackCollider.enabled = false;

   
        if (blackboard.animator != null)
            blackboard.animator.SetBool("Attack", false);

        blackboard.agent.isStopped = false;
    }

    public bool AttackOver()
    {
        return Time.time > attackStartTime + blackboard.attackCooldown;
    }
}
