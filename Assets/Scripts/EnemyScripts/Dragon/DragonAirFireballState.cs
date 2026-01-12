using UnityEngine;

public class DragonAirFireballState : State
{
    private int shotsFired = 0;
    private float cooldown = 1.5f;
    private float lastShot;

    public DragonAirFireballState(Blackboard bb)
    {
        blackboard = bb;
    }

    public override void Enter()
    {
        shotsFired = 0;
        lastShot = Time.time;
    }

    public override void Step()
    {
        if (Time.time > lastShot + cooldown)
        {
            FireProjectile();
            shotsFired++;
            lastShot = Time.time;
        }
    }

    private void FireProjectile()
    {
        GameObject proj = GameObject.Instantiate(
            blackboard.projectilePrefab,
            blackboard.shootPoint.position,
            blackboard.shootPoint.rotation
        );
        Rigidbody rigidbody = proj.GetComponent<Rigidbody>();
        rigidbody.linearVelocity =
            blackboard.shootPoint.forward * blackboard.projectileSpeed;
    }

    public bool FiredEnoughProjectiles()
    {
        return shotsFired >= 5;
    }
}
