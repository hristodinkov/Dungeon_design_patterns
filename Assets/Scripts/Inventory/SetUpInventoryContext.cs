using InventorySystem;
using UnityEngine;

public class SetUpInventoryContext : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerHPBar playerHealth;

    private ItemUseContext context;
    public ItemUseContext Context => context;

    private void Awake()
    {
        context = new ItemUseContext
        {
            Inventory = inventory,
            PlayerHealth = playerHealth
        };
    }
}
