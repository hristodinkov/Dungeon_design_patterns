using UnityEngine; 
public class MoveToRangeState : State
{
    private float optimalRange = 4f;   
    private float minRange = 3f;       
    private float maxRange =5f;      

    public MoveToRangeState(Blackboard bb)
    {
        blackboard = bb;
    }
    public override void Enter()
    {
        base.Enter();

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Idle", false);
            blackboard.animator.SetBool("Chase", true);
            blackboard.animator.SetBool("Aim", false);
        }
    }

    public override void Step()
    {
        base.Step();

        float dist = Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position);

        if (dist > maxRange)
        {
            blackboard.agent.isStopped = false;
            blackboard.agent.SetDestination(blackboard.target.position);
          
            return;
        }

        if (dist < minRange)
        {
            Vector3 dir = (blackboard.enemyTransform.position - blackboard.target.position).normalized;
            Vector3 retreatPos = blackboard.enemyTransform.position + dir * 3f;

            blackboard.agent.isStopped = false;
            blackboard.agent.SetDestination(retreatPos);
            
            return;
        }

        blackboard.agent.isStopped = true;
        
    }
    public override void Exit()
    {
        base.Exit();

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Chase", false);
        }
    }

    public bool InShootRange()
    {
        float dist = Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position);
        float innerMin = minRange + 0.5f;
        float innerMax = maxRange - 0.5f;

        return dist >= innerMin && dist <= innerMax;
    }

    public bool TargetOutOfRange()
    {
        float dist = Vector3.Distance(blackboard.enemyTransform.position, blackboard.target.position);

        return dist > maxRange + 0.5f || dist < minRange - 0.5f;
    }

}
