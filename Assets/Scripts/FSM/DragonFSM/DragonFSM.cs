using UnityEngine;
public class DragonFSM : FSM
{
    private bool phase2Triggered = false;
    public DragonFSM(Blackboard blackboard)
    {

        base.blackboard = blackboard;
      

        var moveState = new MoveState(blackboard);
        var align = new AlignToStateSlow(blackboard.enemyTransform, blackboard);
        var attack = new DragonMeleeAttackState(blackboard);

        var flyUp = new DragonFlyUpState(blackboard);
        var hover = new DragonHoverState(blackboard);
        var airFire = new DragonAirFireballState(blackboard);
        var exhausted = new DragonExhaustedState(blackboard);
        var recover = new DragonRecoverState(blackboard);

        var death = new DeathState(blackboard);

        currentState = moveState;

        // Phase 2 trigger

        attack.transitions.Add(new Transition(IsReadyForPhase2, flyUp));
        moveState.transitions.Add(new Transition(IsReadyForPhase2, flyUp));

        // Phase 1
        moveState.transitions.Add(new Transition(moveState.TargetReached, align));
        align.transitions.Add(new Transition(align.AlignedWithTarget, attack));
        attack.transitions.Add(new Transition(attack.AttackFinished, moveState));
        align.transitions.Add(new Transition(align.TargetOutOfRange, moveState));

        // Phase 2
        flyUp.transitions.Add(new Transition(flyUp.FlyUpFinished, hover));
        hover.transitions.Add(new Transition(hover.HoverFinished, airFire));
        airFire.transitions.Add(new Transition(airFire.FiredEnoughProjectiles, exhausted));
        exhausted.transitions.Add(new Transition(exhausted.RecoveredEnough, recover));
        recover.transitions.Add(new Transition(recover.FinishedRecover, flyUp));
        


        // DEATH
        moveState.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        align.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        attack.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        flyUp.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        airFire.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        exhausted.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        recover.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        
    }

    private bool IsReadyForPhase2()
    {
        if(!phase2Triggered && blackboard.enemyController.CurrentHP <= blackboard.enemyController.MaxHP*blackboard.phase2Threshold)
        {
            phase2Triggered = true;
            blackboard.animator.SetTrigger("Phase2");
            return true;
        }
        return phase2Triggered;
    }

}
