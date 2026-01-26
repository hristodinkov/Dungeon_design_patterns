public class MageFSM : FSM
{
    public MageFSM(Blackboard bb)
    {
        blackboard = bb;

        var idle = new IdleState(bb);
        var move = new MoveToRangeState(bb);
        var align = new AlignToStateMage(bb.enemyTransform, bb);
        var cast = new CastProjectileState(bb);
        var death = new DeathState(bb);

        currentState = idle;

        
        idle.transitions.Add(new Transition(() => idle.IsTargetInRange(), move));

        move.transitions.Add(new Transition(move.InShootRange, align));

        align.transitions.Add(new Transition(align.AlignedWithTarget, cast));

        align.transitions.Add(new Transition(align.TargetOutOfRange, move));

        cast.transitions.Add(new Transition(cast.CastFinished, align));

        idle.transitions.Add(new Transition(bb.enemyController.IsDead, death));
        move.transitions.Add(new Transition(bb.enemyController.IsDead, death));
        align.transitions.Add(new Transition(bb.enemyController.IsDead, death));
        cast.transitions.Add(new Transition(bb.enemyController.IsDead, death));
    
    }
}

