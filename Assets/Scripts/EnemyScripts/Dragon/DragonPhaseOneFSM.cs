public class DragonPhase1FSM : FSM
{
    public DragonPhase1FSM(Blackboard bb)
    {
        blackboard = bb;

        var idle = new IdleState(bb);
        var move = new MoveState(bb);
        var align = new AlignToStateSlow(bb.enemyTransform, bb);
        var attack = new DragonMeleeAttackState(bb);

        currentState = idle;

        idle.transitions.Add(new Transition(idle.IsTargetInRange, move));
        move.transitions.Add(new Transition(move.TargetReached, align));
        align.transitions.Add(new Transition(align.AlignedWithTarget, attack));
        attack.transitions.Add(new Transition(attack.AttackFinished, idle));

        align.transitions.Add(new Transition(align.TargetOutOfRange, move));
        move.transitions.Add(new Transition(move.TargetOutOfRange, idle));
    }
}
