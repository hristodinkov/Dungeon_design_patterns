using InventorySystem;
using UnityEngine;

public class SetUpInventoryContext : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerHPBar playerHealth;
    [SerializeField] private PlayerCombat playerCombat;
    public ItemUseContext Context { get; private set; }

    private void Awake()
    {
        Context = new ItemUseContext
        {
            Inventory = inventory,
            PlayerHealth = playerHealth,
            PlayerCombat = playerCombat
        };
    }
}
