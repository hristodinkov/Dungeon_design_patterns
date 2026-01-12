public class DragonFSM : FSM
{
    public DragonFSM(Blackboard bb)
    {
        blackboard = bb;

        var phase1 = new DragonPhase1FSM(bb);
        var phase2 = new DragonPhase2FSM(bb);
        var death = new DeathState(bb);

        currentState = phase1;

        // Phase 1 ? Phase 2
        phase1.transitions.Add(
            new Transition(() => bb.enemyController.CurrentHP < bb.enemyController.MaxHP * bb.phase2Threshold,phase2));


        // Death transitions
        phase1.transitions.Add(new Transition(bb.enemyController.IsDead, death));
        phase2.transitions.Add(new Transition(bb.enemyController.IsDead, death));
    }
}
