using UnityEngine;

public class DeathState : State
{
    public DeathState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();

        if (blackboard.animator != null)
            blackboard.animator.SetTrigger("Death");
    }

    public override void Step()
    {
        base.Step();
    }
}
