using UnityEngine;

public class IdleState : State
{
    private float startTime;

    public IdleState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();
        startTime = Time.time;

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Idle", true);
            blackboard.animator.SetBool("Chase", false);
            blackboard.animator.SetBool("Aim", false);
        }
            
    }

    public override void Exit()
    {
        base.Exit();

        if (blackboard.animator != null)
            blackboard.animator.SetBool("Idle", false);
    }

    public bool IsTargetInRange()
    {
        if (blackboard.target == null)
            return false;

        return Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position)
               <= blackboard.chaseRange;
    }

    public bool IdleTimeOver(float idleTime)
    {
        return Time.time > startTime + idleTime;
    }
}
