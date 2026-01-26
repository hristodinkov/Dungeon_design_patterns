using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHP;
    public int xp;
    public int attckDamage;
    public int level;
    public int currentHP;

    [Header("Initial Values")] 
    public int initialLevel = 1; 
    public int initialXP = 0; 
    public int initialMaxHP = 100; 
    public int initialCurrentHP = 100;
    public int initialAttackDamage = 5;
    public void ResetToInitial() 
    { 
        level = initialLevel;
        xp = initialXP; 
        maxHP = initialMaxHP; 
        currentHP = initialCurrentHP; 
        attckDamage = initialAttackDamage;
    }

    //public enum PlayerClass
    //{
    //    Warrior,
    //    Mage,
    //    Archer
    //}
}
