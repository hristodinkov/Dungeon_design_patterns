using UnityEngine;

public class DragonFlyUpState : State
{
    private float targetHeight = 10f;

    public DragonFlyUpState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        blackboard.agent.enabled = false;
        blackboard.animator.SetTrigger("FlyUp");
    }

    public override void Step()
    {
        Vector3 pos = blackboard.enemyTransform.position;
        pos.y = Mathf.MoveTowards(pos.y, targetHeight, 5f * Time.deltaTime);
        blackboard.enemyTransform.position = pos;
    }

    public bool ReachedAirHeight()
    {
        return blackboard.enemyTransform.position.y >= targetHeight - 0.1f;
    }
}
