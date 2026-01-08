public class UseItemCreator 
{
    public static UseItem Create(Item item)
    {
        return item.UseType switch
        {
            ItemUseType.Consume => new ConsumeItem(),
            ItemUseType.Equip => new EquipItem(),
            _ => null,
        };
    }
}
