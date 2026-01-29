using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemyController = other.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                if(playerCombat.CurrentDamage != null)
                {
                    enemyController.ApplyHit(playerCombat.CurrentDamage);
                }
                else
                {
                    enemyController.ApplyHit(new DamageData(5));
                }
            }
        }
    }
}
