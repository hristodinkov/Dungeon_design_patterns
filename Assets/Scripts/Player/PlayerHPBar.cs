using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : PlayerObserver
{
    [SerializeField]
    private Image hpBarImage;
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private TextMeshProUGUI hpText;

    private float maxHP;
    private float currentHP;
    
    private void Start()
    {
        maxHP = playerData.maxHP;
        currentHP = playerData.maxHP;
        
    }
    protected override void OnHit(DamageData damageData, PlayerData playerData)
    {
        currentHP = playerData.currentHP;
        UpdateHPBar();
    }
    private void UpdateHPBar()
    {
        hpBarImage.fillAmount = currentHP / maxHP;
        hpText.text = $"{currentHP} / {maxHP}";
    }
    public void Heal(int healAmount)
    {
        playerData.currentHP += healAmount;
        if (playerData.currentHP > playerData.maxHP)
        {
            playerData.currentHP = playerData.maxHP;
        }
        currentHP = playerData.currentHP;
        UpdateHPBar();
    }

    protected override void OnHeal(int healAmount)
    {
        Heal(healAmount);
    }
}
