using UnityEngine;

public class MoveState : State
{
    public MoveState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();

        blackboard.agent.enabled = true;
        blackboard.agent.isStopped = false;

        blackboard.agent.stoppingDistance = blackboard.attackRange * 1.2f;
        if (blackboard.target != null)
            blackboard.agent.SetDestination(blackboard.target.position);

        if (blackboard.animator != null)
        {
            if (blackboard.enemyType != EnemyType.Dragon)
            {
                blackboard.animator.SetBool("Idle", false);
            }
            blackboard.animator.SetBool("Aim", false);
            blackboard.animator.SetBool("Attack", false);
            blackboard.animator.SetBool("Chase", true);
        }
            
    }

    public override void Step()
    {
        base.Step();
        Vector3 dir = (blackboard.target.position - blackboard.enemyTransform.position).normalized; 
        dir.y = 0; 
        Quaternion lookRot = Quaternion.LookRotation(dir); 
        blackboard.enemyTransform.rotation = Quaternion.Slerp(blackboard.enemyTransform.rotation, lookRot, Time.deltaTime * 5f);

        if (blackboard.target != null)
            blackboard.agent.SetDestination(blackboard.target.position);

    }

    public override void Exit()
    {
        if (blackboard.agent == null || blackboard.target == null) return; 
      
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        Vector3 toTarget = blackboard.target.position - blackboard.enemyTransform.position; 
        float distance = toTarget.magnitude;
        
        if (distance < 0.01f) 
            return; 

        Vector3 dir = toTarget / distance; 
        float desiredDistance = blackboard.attackRange - 0.5f; 
        desiredDistance = Mathf.Max(1f, desiredDistance); 
        Vector3 dest = blackboard.target.position - dir * desiredDistance; 
        blackboard.agent.SetDestination(dest); 
    }

    public bool TargetReached()
    {
        return blackboard.agent.remainingDistance <= blackboard.attackRange;
    }

    public bool TargetOutOfRange()
    {
        if (blackboard.target == null)
            return true;

        float dist = Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position);
        return dist > blackboard.chaseRange;
    }
}
