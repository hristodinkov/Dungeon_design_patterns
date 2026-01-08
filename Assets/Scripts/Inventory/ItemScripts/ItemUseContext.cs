using InventorySystem;

[System.Serializable]
public class ItemUseContext 
{
    public Inventory Inventory;
    public PlayerHPBar PlayerHealth;
    public Item SelectedItem;
    public PlayerCombat PlayerCombat;
    //public EquipmentSystem Equipment;
}
