using UnityEngine;
using System;
public class CastProjectileState : State
{
    private float startTime;
    private bool projectileFired = false;
    private float castDelay = 0.7f; 

    public CastProjectileState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        base.Enter();

        blackboard.agent.isStopped = true;
        projectileFired = false;
        startTime = Time.time;

        if (blackboard.animator != null)
        {
            blackboard.animator.SetBool("Idle", false);
            blackboard.animator.SetBool("Chase", false);
            blackboard.animator.SetTrigger("Attack");
        } 
    }

    public override void Step()
    {
        base.Step();

        float elapsed = Time.time - startTime;

        if (!projectileFired && elapsed >= castDelay)
        {
            projectileFired = true;
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        if (blackboard.projectilePrefab == null || blackboard.shootPoint == null)
            return;

        GameObject proj = GameObject.Instantiate(
            blackboard.projectilePrefab,
            blackboard.shootPoint.position,
            blackboard.shootPoint.rotation
        );

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = blackboard.shootPoint.forward * blackboard.projectileSpeed;
        }
    }


    public bool CastFinished()
    {
        return Time.time > startTime + blackboard.attackCooldown;
    }
}
