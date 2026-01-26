using StarterAssets;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        // List of item data assets used to generate actual items at runtime.
        [SerializeField]
        private List<ItemData> itemDatas;

        // List of instantiated items currently in the inventory.
        [SerializeReference]
        private List<Item> items;

        // Public read-only property to access a copy of the items list.
        public Item[] Items => items.ToArray();

        // MonoBehaviour-based sorting strategies.
        [SerializeField]
        private ItemSortingStrategy[] itemSortingStrategies;

        // Index of the currently active sorting strategy.
        [SerializeField]
        private int strategyIndex = 0;

        // Event triggered when the inventory changes.
        public static Action OnInventoryChanged;

        

        //[SerializeField] private GameObject inventoryUI;
        //[SerializeField] private Key toggleKey = Key.I;
        //[SerializeField] private InventoryPresenter inventoryPresenter;
        //[SerializeField] private StarterAssetsInputs starterAssetsInputs;

        private void Awake()
        {
            GenerateInventory();             // Create items based on itemDatas.
            LoadItemSortingStrategies();     // Find sorting strategies attached as components.
        }

        // Instantiates items based on the item data list.
        private void GenerateInventory()
        {
            items = new List<Item>();
            foreach (ItemData itemData in itemDatas)
            {
                items.Add(itemData.CreateItem()); // Create an item from its data.
            }
        }

        // Adds an item to the inventory.
        public void AddItem(Item newItem)
        {
            if (newItem.IsStackable)
            {
                Item stack = items.Find(i => i.Id == newItem.Id);

                if (stack != null)
                {
                    stack.Add(1);
                    OnInventoryChanged?.Invoke();
                    return;
                }
            }

            items.Add(newItem);
            OnInventoryChanged?.Invoke();
        }

        // Removes an item from the inventory.
        public void RemoveItem(Item item)
        {
            items.Remove(item);
            OnInventoryChanged?.Invoke();
        }

        private void Update()
        {
            //if (Keyboard.current[Key.I].wasPressedThisFrame)
            //{
            //    inventoryPresenter.gameObject.SetActive(!inventoryUI.activeSelf);
            //    inventoryUI.SetActive(!inventoryUI.activeSelf);
            //    starterAssetsInputs.cursorLocked = !inventoryUI.activeSelf;
            //}
        }


        #region Sorting Strategies
        private void LoadItemSortingStrategies()
        {
            itemSortingStrategies = GetComponentsInChildren<ItemSortingStrategy>();
        }

        // Returns the items sorted according to the current strategy.
        public Item[] GetSortedItems()
        {
            // If no sorting strategies exist, return the unsorted list.
            if (itemSortingStrategies.Length == 0)
            {
                return items.ToArray();
            }
            else
            {
                return itemSortingStrategies[strategyIndex].GetSortedItems(items);
            }
        }

        // Sets the current sorting strategy by index.
        public void SetSortingStrategy(int pIndex)
        {
            strategyIndex = pIndex;
        }

        // Cycles to the next sorting strategy (loops back to 0 if at the end).
        public void NextSortingStrategy()
        {
            if (strategyIndex == itemSortingStrategies.Length - 1)
            {
                strategyIndex = 0;
            }
            else
            {
                strategyIndex++;
            }
        }

        // Cycles to the previous sorting strategy (loops to last if at the start).
        public void PreviousSortingStrategy()
        {
            if (strategyIndex == 0)
            {
                strategyIndex = itemSortingStrategies.Length - 1;
            }
            else
            {
                strategyIndex--;
            }
        }

        // Returns the name of the currently selected sorting strategy.
        public string GetCurrentStrategyName()
        {
            return itemSortingStrategies[strategyIndex].StrategyName;
        }
        #endregion
    }
}
