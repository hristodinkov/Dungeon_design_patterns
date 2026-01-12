using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerData = other.gameObject.GetComponent<PlayerController>();
            DamageData damageData = new DamageData(damage);

            if (playerData != null)
            {
                playerData.GetHit(damageData);
            }
        }
        if (gameObject.CompareTag("Sphere"))
        {
            Destroy(gameObject);
        }
    }
}
