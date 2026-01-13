using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player == null)
            return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
