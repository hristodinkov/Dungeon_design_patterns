using InventorySystem;
using System;
using UnityEngine;

public class ConsumeItem : UseItem
{
    public override bool CanUse(Item item, ItemUseContext context)
    {
        return item.UseType==ItemUseType.Consume && item.HealAmount > 0;
    }

    public override void Execute(Item item, ItemUseContext context)
    {
        context.PlayerHealth.Heal(item.HealAmount); 
        item.Remove(1);
        
        if (item.Quantity == 0) 
            context.Inventory.RemoveItem(item);
        Inventory.OnInventoryChanged?.Invoke();
    }
}
