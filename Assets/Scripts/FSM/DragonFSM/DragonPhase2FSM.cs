public class DragonPhase2FSM : FSM
{
    public DragonPhase2FSM(Blackboard bb)
    {
        blackboard = bb;

        var flyUp = new DragonFlyUpState(bb);
        var airFire = new DragonAirFireballState(bb);
        var exhausted = new DragonExhaustedState(bb);
        var recover = new DragonRecoverState(bb);
        var runAway = new DragonRunAwayState(bb);

        currentState = flyUp;

        flyUp.transitions.Add(new Transition(flyUp.ReachedAirHeight, airFire));
        airFire.transitions.Add(new Transition(airFire.FiredEnoughProjectiles, exhausted));
        exhausted.transitions.Add(new Transition(exhausted.RecoveredEnough, recover));
        recover.transitions.Add(new Transition(recover.FinishedRecover, runAway));
        runAway.transitions.Add(new Transition(runAway.FinishedRun, flyUp));

    }
}
