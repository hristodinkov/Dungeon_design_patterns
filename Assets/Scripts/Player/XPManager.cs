using UnityEngine;

public class XPManager : MonoBehaviour
{
    [Header("XP Settings")]
    [SerializeField] private int level = 1;
    [SerializeField] private int currentXP = 0;
    [SerializeField] private int xpToNextLevel = 100;

    [Header("References")]
    [SerializeField] private PlayerData playerdata;
    [SerializeField] private PlayerHPBar playerHealth;
    [SerializeField] private XPUI xpUI;

    private void OnEnable()
    {
        EnemyEventBus.OnEnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        EnemyEventBus.OnEnemyDied -= OnEnemyDied;
    }

    private void Start()
    {
        level = playerdata.level;
        currentXP = playerdata.xp;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        AddXP(enemy.XP);
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        while (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }

        xpUI.UpdateUI(level, currentXP, xpToNextLevel);
    }

    private void LevelUp()
    {
        currentXP -= xpToNextLevel;
        level++;
        
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.25f);
        playerdata.level = level;
        playerdata.xp = currentXP;
        playerHealth.SetMaxHealth(10);
    }
}
