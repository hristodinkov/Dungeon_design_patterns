using UnityEngine;

public class AlignToState : State
{
    private Transform self;
    private Vector3 direction;
    private float rotationSign;

    public AlignToState(Transform pSelf, Blackboard pBlackboard)
    {
        self = pSelf;
        blackboard = pBlackboard;
    }

    public override void Enter()
    {
        base.Enter();

        if (blackboard.target != null)
        {
            UpdateDirection(blackboard.target.position);
        }
       
    }

    public override void Step()
    {
        base.Step();

    
        if (blackboard.target != null)
        {
            UpdateDirection(blackboard.target.position);
        }

       
        self.Rotate(
            self.up,
            rotationSign * blackboard.rotateSpeed * Time.deltaTime
        );
    }

    private void UpdateDirection(Vector3 targetPos)
    {
        direction = (targetPos - self.position).normalized;
        rotationSign = Mathf.Sign(Vector3.Dot(self.right, direction));
    }

    public bool AlignedWithTarget()
    {
        return Vector3.Dot(self.forward, direction) >= 0.95f;
    }

    public bool TargetOutOfRange()
    {
        if (blackboard.target == null)
            return true;

        return Vector3.Distance(self.position, blackboard.target.position) > blackboard.attackRange;
    }
}
