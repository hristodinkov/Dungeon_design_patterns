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

        blackboard.agent.isStopped = false;

        if (blackboard.target != null)
            blackboard.agent.SetDestination(blackboard.target.position);

        if (blackboard.animator != null)
            blackboard.animator.SetBool("Chase", true);
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
        base.Exit();

        blackboard.agent.isStopped = true;

        if (blackboard.animator != null)
            blackboard.animator.SetBool("Chase", false);
    }

    public bool TargetReached()
    {
        if (blackboard.target == null)
            return false;

        float dist = Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position);
        return dist <= blackboard.attackRange;
    }

    public bool TargetOutOfRange()
    {
        if (blackboard.target == null)
            return true;

        float dist = Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position);
        return dist > blackboard.chaseRange;
    }
}
