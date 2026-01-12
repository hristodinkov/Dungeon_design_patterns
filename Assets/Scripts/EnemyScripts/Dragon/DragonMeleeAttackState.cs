using UnityEngine;

public class DragonMeleeAttackState : State
{
    private float attackDuration = 1.5f;     // ????? ????? ???? ???????
    private float damageTime = 0.6f;         // ???? ?? ?????? damage (? ???.)
    private bool hasDealtDamage = false;
    private float startTime;

    private float attackRange = 10f;          // ??-????? range ?? ????? ????
    private int damage = 20;                 // ????? ?? ???? ???????

    

    public DragonMeleeAttackState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        startTime = Time.time;
        hasDealtDamage = false;

        blackboard.animator.SetTrigger("Attack");

        
        if (blackboard.agent != null)
        {
            blackboard.agent.isStopped = true;
        }
    }

    public override void Step()
    {
        float elapsed = Time.time - startTime;

    }

    public bool AttackFinished()
    {
        return Time.time >= startTime + attackDuration;
    }
}
