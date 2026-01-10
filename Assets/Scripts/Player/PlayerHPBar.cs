using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : PlayerObserver
{
    //[SerializeField]
    //private Image hpBarImage;
    [SerializeField]
    private Slider hpBarSlider;
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private TextMeshProUGUI hpText;

    private float maxHP;
    private float currentHP;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


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
        //hpBarImage.fillAmount = currentHP / maxHP;
        hpBarSlider.value = currentHP / maxHP;
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

    public void SetMaxHealth(int hPToAdd)
    {
        playerData.maxHP += hPToAdd;
        maxHP += hPToAdd;
        hpBarSlider.maxValue = 1f;
        HealToMaxHealth();
        UpdateHPBar();
    }

    protected void HealToMaxHealth()
    {
        playerData.currentHP = playerData.maxHP;
        currentHP = playerData.currentHP;
    }


}
