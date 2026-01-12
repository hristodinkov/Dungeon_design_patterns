using UnityEngine;

public class DragonExhaustedState : State
{
    private float startTime;

    public DragonExhaustedState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        startTime = Time.time;
        blackboard.animator.SetTrigger("FallExhausted");
    }

    public override void Step()
    {
        Vector3 pos = blackboard.enemyTransform.position;
        pos.y = Mathf.MoveTowards(pos.y, 0f, 5f * Time.deltaTime);
        blackboard.enemyTransform.position = pos;
    }

    public bool RecoveredEnough()
    {
        return Time.time > startTime + 5f;
    }
}
