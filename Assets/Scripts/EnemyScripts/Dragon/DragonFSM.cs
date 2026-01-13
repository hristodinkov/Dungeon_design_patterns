using UnityEngine;
public class DragonFSM : FSM
{
    
    public DragonFSM(Blackboard blackboard)
    {
        base.blackboard = blackboard;
        

        // STATES
        var movePhase1 = new MoveState(blackboard);
        var movePhase2 = new MoveStatePhase2(blackboard);
        var align = new AlignToStateSlow(blackboard.enemyTransform, blackboard);
        var attack = new DragonMeleeAttackState(blackboard);

        var flyUp = new DragonFlyUpState(blackboard);
        var hover = new DragonHoverState(blackboard);
        var airFire = new DragonAirFireballState(blackboard);
        var exhausted = new DragonExhaustedState(blackboard);
        var recover = new DragonRecoverState(blackboard);

        var death = new DeathState(blackboard);

        // START
        currentState = movePhase1;

        // PHASE 1 FLOW
        movePhase1.transitions.Add(new Transition(movePhase1.TargetReached, align));
        align.transitions.Add(new Transition(align.AlignedWithTarget, attack));
        attack.transitions.Add(new Transition(attack.AttackFinished, movePhase1));
        align.transitions.Add(new Transition(align.TargetOutOfRange, movePhase1));

        // PHASE 2 TRIGGER
        movePhase1.transitions.Add(new Transition(IsReadyForPhase2, movePhase2));

        //PHASE 2
        attack.transitions.Add(new Transition(attack.AttackFinished, movePhase2));

        // AIR PHASE
        movePhase2.transitions.Add(new Transition(IsReadyForPhase2, flyUp));
        // FLY TO ATTACK
        flyUp.transitions.Add(new Transition(flyUp.ReachedAirHeight, airFire));
        //ATTACK TO EXHAUST
        airFire.transitions.Add(new Transition(airFire.FiredEnoughProjectiles, exhausted));
        //EXHAUST TO RECOVER
        exhausted.transitions.Add(new Transition(exhausted.RecoveredEnough, recover));
        //RECOVER TO START THE PHASE2 AGAIN
        recover.transitions.Add(new Transition(recover.FinishedRecover, movePhase2));
        //TRANSITION FLY STATES
        flyUp.transitions.Add(new Transition(flyUp.FlyUpFinished, hover)); 
        hover.transitions.Add(new Transition(hover.HoverFinished, airFire));


        // DEATH
        movePhase1.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        movePhase2.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        align.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        attack.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        flyUp.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        airFire.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        exhausted.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        recover.transitions.Add(new Transition(blackboard.enemyController.IsDead, death));
        
    }

    private bool IsReadyForPhase2()
    {
        if(blackboard.enemyController.CurrentHP <= blackboard.enemyController.MaxHP*blackboard.phase2Threshold)
        {
            blackboard.animator.SetTrigger("Phase2");
            return true;
        }
        return false;
    }

}
