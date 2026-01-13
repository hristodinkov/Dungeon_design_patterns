using UnityEngine;
public class MovePhase1State : State
{
    public MovePhase1State(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        blackboard.agent.isStopped = false;
        blackboard.animator.SetBool("Chase", true);
        UpdateDestination();
    }

    public override void Step()
    {
        if (blackboard.target == null)
            return;

        Vector3 dir = (blackboard.target.position - blackboard.enemyTransform.position).normalized;
        dir.y = 0;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        blackboard.enemyTransform.rotation = Quaternion.Slerp(
            blackboard.enemyTransform.rotation,
            lookRot,
            Time.deltaTime * 5f
        );

        
        UpdateDestination();
    }

    public bool TargetReached()
    {
        return blackboard.agent.remainingDistance <= 0.3f
               && !blackboard.agent.pathPending;
    }



    private void UpdateDestination()
    {
        Vector3 toTarget = blackboard.target.position - blackboard.enemyTransform.position;
        float distance = toTarget.magnitude;

        if (distance < 0.01f) return;

        Vector3 dir = toTarget.normalized;
        float desiredDistance = blackboard.attackRange - 0.5f;
        Vector3 dest = blackboard.target.position - dir * desiredDistance;

        blackboard.agent.SetDestination(dest);
    }

}
