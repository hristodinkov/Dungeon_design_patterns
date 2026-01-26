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
        blackboard.dragonCollider.enabled = false;
    }
    public override void Step()
    {
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        if (blackboard.target == null)
            return;

        Vector3 dir = (blackboard.target.position - blackboard.enemyTransform.position).normalized;
        dir.y = 0;

        Quaternion lookRot = Quaternion.LookRotation(dir);
        blackboard.enemyTransform.rotation = Quaternion.Slerp(
            blackboard.enemyTransform.rotation,
            lookRot,
            Time.deltaTime * 2f
        );
    }


    public bool ReachedAirHeight()
    {
        return blackboard.enemyTransform.position.y >= targetHeight - 0.1f;
    }

    public bool FlyUpFinished()
    {
        AnimatorStateInfo info = blackboard.animator.GetCurrentAnimatorStateInfo(0);
        return info.IsName("Take Off") && info.normalizedTime >= 1f;
    }



}
