using UnityEngine;

public abstract class PlayerObserver : MonoBehaviour
{
    [SerializeField]
    protected PlayerController playerController;

    protected void OnEnable()
    {
        playerController.onHit += OnHit;
        playerController.onHeal += OnHeal;
    }
    
    protected void OnDisable()
    {
        playerController.onHeal -= OnHeal;
        playerController.onHit -= OnHit;
    }

    

    protected abstract void OnHit(DamageData damageData,PlayerData playerData);

    protected abstract void OnHeal(int healAmount);
}
