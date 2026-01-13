using UnityEngine;

public class DragonHoverState : State
{
    public DragonHoverState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        blackboard.animator.ResetTrigger("FlyUp");
        blackboard.animator.SetTrigger("Hover");
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

    public bool HoverFinished()
    {
        AnimatorStateInfo info = blackboard.animator.GetCurrentAnimatorStateInfo(0);
        return info.IsName("Fly Float") && info.normalizedTime >= 1f;
    }
}
