public class SkeletonFSM : FSM
{
    public SkeletonFSM(Blackboard bb)
    {
        blackboard = bb;

        var idle = new IdleState(bb);
        var move = new SkeletonMoveState(bb);
        var align = new AlignToState(bb.enemyTransform, bb);
        var attack = new AttackState(bb);
        var death = new DeathState(bb);

        currentState = idle;

        idle.transitions.Add(new Transition(idle.IsTargetInRange, move));
        move.transitions.Add(new Transition(move.TargetReached, align));
        align.transitions.Add(new Transition(align.AlignedWithTarget, attack));
        attack.transitions.Add(new Transition(attack.AttackOver, idle));

        align.transitions.Add(new Transition(align.TargetOutOfRange, move));
        move.transitions.Add(new Transition(move.TargetOutOfRange, idle));
        

        idle.transitions.Add(new Transition(()=>bb.enemyController.IsDead, death));
        move.transitions.Add(new Transition(() => bb.enemyController.IsDead, death));
        align.transitions.Add(new Transition(() => bb.enemyController.IsDead, death));
        attack.transitions.Add(new Transition(() => bb.enemyController.IsDead, death));
    }
}

