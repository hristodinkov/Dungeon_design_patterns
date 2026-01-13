public class DragonPhase1FSM : FSM
{
    public DragonPhase1FSM(Blackboard bb,DragonPhase2FSM phase2)
    {
        blackboard = bb;
        var move = new MoveState(bb);
        var align = new AlignToStateSlow(bb.enemyTransform, bb);
        var attack = new DragonMeleeAttackState(bb);

        currentState = move;

        // MOVE to ALIGN 
        move.transitions.Add(new Transition(move.TargetReached, align));

        // ALIGN to ATTACK 
        align.transitions.Add(new Transition(() => align.AlignedWithTarget() && attack.InAttackRange(),attack));

        // ATTACK to MOVE 
        attack.transitions.Add(new Transition(attack.AttackFinished, move));

        
        align.transitions.Add(new Transition(align.TargetOutOfRange, move));

        //move.transitions.Add(new Transition(move.TargetOutOfRange, move));

        move.transitions.Add(new Transition(() => bb.enemyController.CurrentHP <= bb.enemyController.MaxHP * bb.phase2Threshold, phase2));
        align.transitions.Add(new Transition(() => bb.enemyController.CurrentHP <= bb.enemyController.MaxHP * bb.phase2Threshold, phase2)); 
        attack.transitions.Add(new Transition(() => bb.enemyController.CurrentHP <= bb.enemyController.MaxHP * bb.phase2Threshold, phase2));
    }
}
