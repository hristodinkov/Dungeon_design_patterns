using UnityEngine;

public class AlignToStateMage : State
{
    private Transform self;
    private const float minRange = 3f; 
    private const float maxRange = 8f;

    public AlignToStateMage(Transform selfTransform, Blackboard bb)
    {
        self = selfTransform;
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();

        if (blackboard.agent != null)
            blackboard.agent.isStopped = true;

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Idle", false);
            blackboard.animator.SetBool("Chase", false);
            blackboard.animator.SetBool("Aim", true);
        }
            
    }
    public override void Step()
    {
        base.Step();

        if (blackboard.target == null)
            return;

        Vector3 toTarget = blackboard.target.position - self.position;
        toTarget.y = 0f;

        if (toTarget.sqrMagnitude < 0.001f)
            return;

        Quaternion targetRot = Quaternion.LookRotation(toTarget.normalized);
        self.rotation = Quaternion.RotateTowards(
            self.rotation,
            targetRot,
            blackboard.rotateSpeed * Time.deltaTime
        );
    }

    public override void Exit()
    {
        base.Exit();

        if (blackboard.animator != null)
            blackboard.animator.SetBool("Aim", false);

        
        if (blackboard.agent != null)
            blackboard.agent.isStopped = false;
    }

    public bool AlignedWithTarget()
    {
        if (blackboard.target == null)
            return false;

        Vector3 toTarget = blackboard.target.position - self.position;
        toTarget.y = 0f;

        if (toTarget.sqrMagnitude < 0.001f)
            return false;

        Quaternion targetRot = Quaternion.LookRotation(toTarget.normalized);
        float angle = Quaternion.Angle(self.rotation, targetRot);

        return angle < 5f; 
    }

    public bool TargetOutOfRange()
    {
        if (blackboard.target == null)
            return true;

        float dist = Vector3.Distance(self.position, blackboard.target.position);
    
        float outerMin = minRange - 0.5f; 
        float outerMax = maxRange + 0.5f;

        return dist < outerMin || dist > outerMax;
    }

}


