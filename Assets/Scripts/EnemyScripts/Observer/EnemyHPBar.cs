using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Todo: finish this class so that when the enemy get's hit, its health bar's
/// fillAmount will be reduced to represent the current health. Add new fields/methods
/// if necessary. 
/// </summary>
public class EnemyHPBar : EnemyObserver
{
    [SerializeField]
    private Image hpBar;
    private float maxHP = 50;
    private float currentHP;

    protected override void OnEnemyCreated(Enemy enemy)
    {
        maxHP = enemy.MaxHP;
        currentHP = maxHP;
    }

    protected override void OnEnemyDie(Enemy enemy)
    {
        // No implementation needed for now
    }

    protected override void OnEnemyHit(Enemy enemy, DamageData damageData)
    {
        currentHP -= damageData.damage;
        hpBar.fillAmount = currentHP/maxHP;
        
    }

}
