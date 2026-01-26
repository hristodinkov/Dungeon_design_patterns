using UnityEngine;

public class DragonRunAwayState : State
{
    private float runDistance = 12f;
    private Vector3 targetPos;

    public DragonRunAwayState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        if (blackboard.agent != null)
        {
            blackboard.agent.enabled = true;
            blackboard.agent.isStopped = false;
        }

        Vector3 dir = (blackboard.enemyTransform.position - blackboard.target.position).normalized;
        targetPos = blackboard.enemyTransform.position + dir * runDistance;

        blackboard.agent.SetDestination(targetPos);

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Chase", true);
            blackboard.animator.SetBool("Idle", false);
            blackboard.animator.SetBool("Aim", false);
        }
    }

    public override void Step()
    {
        //no implemetation needed
    }

    public bool FinishedRun()
    {
        if (blackboard.agent == null)
            return true;

        return !blackboard.agent.pathPending &&
               blackboard.agent.remainingDistance < 0.5f;
    }
}
