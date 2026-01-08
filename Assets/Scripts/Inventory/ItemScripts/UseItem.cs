using UnityEngine;

public abstract class UseItem 
{
    public abstract bool CanUse(Item item,ItemUseContext context);
    public abstract void Execute(Item item,ItemUseContext context);
}
