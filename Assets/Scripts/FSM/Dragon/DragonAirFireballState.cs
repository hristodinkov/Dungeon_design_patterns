using UnityEngine;

public class DragonAirFireballState : State
{
    private int shotsFired = 0;
    private float cooldown = 0.7f;
    private float lastShot;

    public DragonAirFireballState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        shotsFired = 0;
        lastShot = Time.time;

        blackboard.animator.SetBool("Aim", true);
    }


    public override void Step()
    {
        if (blackboard.target != null)
        {
            Vector3 dir = (blackboard.target.position - blackboard.shootPoint.position).normalized;
            dir.y = 0; 
            Quaternion lookRot = Quaternion.LookRotation(dir);
            blackboard.enemyTransform.rotation = Quaternion.Slerp(
                blackboard.enemyTransform.rotation,
                lookRot,
                Time.deltaTime * 2f
            );
        }

        if (Time.time > lastShot + cooldown)
        {
            FireProjectile();
            shotsFired++;
            lastShot = Time.time;
        }
    }


    private void FireProjectile()
    {
        Vector3 dir = (blackboard.target.position - blackboard.shootPoint.position).normalized;

        GameObject proj = GameObject.Instantiate(
            blackboard.projectilePrefab,
            blackboard.shootPoint.position,
            Quaternion.LookRotation(dir)
        );

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = dir * blackboard.projectileSpeed;
    }


    public bool FiredEnoughProjectiles()
    {
        if(shotsFired>=3)
        {
            blackboard.animator.SetTrigger("FallExhausted");
            return true;
        }
        return false;
    }
}
