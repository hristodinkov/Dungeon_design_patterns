using UnityEngine;

public class EquipItem : UseItem
{
    public override bool CanUse(Item item, ItemUseContext context)
    {
        if (item.DamageData.damage > 0)
        {
            return true;
        }
       return false;
    }

    public override void Execute(Item item, ItemUseContext context)
    {
        context.PlayerCombat.SetUpSword(item.DamageData, item.itemModel);
    }
}
