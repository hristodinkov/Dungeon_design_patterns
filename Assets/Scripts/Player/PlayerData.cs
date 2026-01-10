using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHP;
    public float speed;
    public int money;
    public int xp;
    public int attckDamage;
    public int level;
    public int currentHP;

    [Header("Initial Values")] 
    public int initialLevel = 1; 
    public int initialXP = 0; 
    public int initialMaxHP = 100; 
    public int initialCurrentHP = 100;
    public float initialSpeed = 5f;
    public int initialMoney = 0;
    public int initialAttackDamage = 5;
    public void ResetToInitial() 
    { 
        level = initialLevel;
        xp = initialXP; 
        maxHP = initialMaxHP; 
        currentHP = initialCurrentHP; 
        speed = initialSpeed;
        money = initialMoney;
        attckDamage = initialAttackDamage;
    }

    //public enum PlayerClass
    //{
    //    Warrior,
    //    Mage,
    //    Archer
    //}
}
