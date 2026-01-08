using InventorySystem;
using System;
using UnityEngine;
using static InventorySystem.ItemData;

[Serializable]
public class Item 
{
    [Header("Unique id for each item")]
    [SerializeField]
    private string id;
    public string Id => id;//This setup allows access to the private field 'id'
                           //while also allows it to be shown in the inspector

    [Header("Core properties")]
    [SerializeField]
    private string itemName;
    public string ItemName => itemName;
    [SerializeField]
    private int attack;
    public int Attack => attack;

    [SerializeField]
    private int defense;

    public int Defense => defense;

    [SerializeField]
    public bool isStackable;
    public bool IsStackable => isStackable;

    [SerializeField]
    private int healAmount;
    public int HealAmount => healAmount;

    [SerializeField]
    private int quantity = 1;
    public int Quantity => quantity;

    private ItemUseType useType;
    public ItemUseType UseType => useType;

    [SerializeField]
    private DamageData damageData;

    public DamageData DamageData => damageData;

    [Header("Visuals")]
    public Sprite itemIcon;
    public GameObject itemModel;

    public void Add(int amount)
    {
        quantity += amount;
    }

    public void Remove(int amount)
    {
        quantity -= amount;
        if (quantity < 0)
            quantity = 0;
    }

    public Item(ItemData itemData)
    {
        id = itemData.id;
        itemName = itemData.itemName;
        attack = itemData.attack;
        defense = itemData.defense;
        isStackable = itemData.isStackable;
        healAmount = itemData.healAmount;
        quantity = itemData.quantity;
        itemIcon = itemData.itemIcon;
        itemModel = itemData.itemModel;
        useType = itemData.useType;
        if (itemData.attack > 0)
        {
            damageData = new DamageData(itemData.attack);
        }
    }
}
