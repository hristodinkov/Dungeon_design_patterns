public class UseItemCreator 
{
    public static UseItem Create(Item item)
    {
        switch (item.UseType) 
        { 
            case ItemUseType.Consume:
                return new ConsumeItem();
            case ItemUseType.Equip:
                return new EquipItem();
            default:
                return null;
        }
    }
}
