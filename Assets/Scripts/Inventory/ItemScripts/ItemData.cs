using System;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [Header("Unique id for each item")]
        public string id;

        [Header("Core properties")]
        public string itemName;
        public int attack;
        public int defense;
        public bool isStackable = false;
        public int healAmount = 0;
        public int quantity = 1;
        
        public ItemUseType useType;

        [Header("Visuals")]
        public Sprite itemIcon;
        public GameObject itemModel;
        public Item CreateItem()
        {
            return new Item(this);
        }
        

    }
}

