using UnityEngine;

public abstract class PlayerObserver : MonoBehaviour
{
    [SerializeField]
    protected PlayerController playerController;

    protected void OnEnable()
    {
        playerController.onHit += OnHit;
        playerController.onHeal += OnHeal;
        playerController.onDie += OnDie;
    }
    
    protected void OnDisable()
    {
        playerController.onHeal -= OnHeal;
        playerController.onHit -= OnHit;
        playerController.onDie -= OnDie;
    }

    protected abstract void OnHit(DamageData damageData,PlayerData playerData);

    protected abstract void OnHeal(int healAmount);

    protected abstract void OnDie();
}
