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
                    enemyController.GetHit(playerCombat.CurrentDamage);
                }
                else
                {
                    enemyController.GetHit(new DamageData(5));
                }
            }
        }
    }
}
