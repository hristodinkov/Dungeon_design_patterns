using UnityEngine;

public class DragonRecoverState : State
{
    private float startTime;

    public DragonRecoverState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        startTime = Time.time;
        blackboard.animator.SetTrigger("Recover");
    }

    public bool FinishedRecover()
    {
        return Time.time > startTime + 2f;
    }
}
