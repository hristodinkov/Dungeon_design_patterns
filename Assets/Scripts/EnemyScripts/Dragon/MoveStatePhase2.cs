using UnityEngine;

public class MoveStatePhase2 : State
{
    private float fleeDistance = 12f; 

    public MoveStatePhase2(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();

        blackboard.agent.enabled = true;
        blackboard.agent.isStopped = false;

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Idle", false);
            blackboard.animator.SetBool("Aim", false);
            blackboard.animator.SetBool("Attack", false);
            blackboard.animator.SetBool("Chase", true); 
        }

        UpdateDestination();
    }

    public override void Step()
    {
        base.Step();

        if (blackboard.target == null)
            return;

        // ??????? ??? ?????? (??? ????? ???? ??? ????? ?? ????? ??????)
        Vector3 dir = (blackboard.target.position - blackboard.enemyTransform.position).normalized;
        dir.y = 0;
        Quaternion lookRot = Quaternion.LookRotation(-dir); // ????? ????? ?????? ????
        blackboard.enemyTransform.rotation = Quaternion.Slerp(
            blackboard.enemyTransform.rotation,
            lookRot,
            Time.deltaTime * 3f
        );

        UpdateDestination();
    }

    private void UpdateDestination()
    {
        Vector3 away = (blackboard.enemyTransform.position - blackboard.target.position).normalized;
        away.y = 0;

        Vector3 dest = blackboard.enemyTransform.position + away * fleeDistance;

        blackboard.agent.SetDestination(dest);
    }

    public bool FarEnough()
    {
        float dist = Vector3.Distance(
            blackboard.enemyTransform.position,
            blackboard.target.position
        );

        return dist >= fleeDistance * 0.9f;
    }
}
