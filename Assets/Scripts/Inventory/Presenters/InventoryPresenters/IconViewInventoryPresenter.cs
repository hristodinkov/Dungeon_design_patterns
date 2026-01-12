using IneventorySystem;
using InventorySystem;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
public class IconViewInventoryPresenter : InventoryPresenter
{
    [SerializeField]
    private ItemPresenter itemPresenterPrefab;
    // Parent transform under which item UI elements will be instantiated.
    public Transform listParent;

    // UI text element that displays the name of the current sorting strategy.
    [SerializeField]
    private TextMeshProUGUI sortingStrategyNameText;

    [SerializeField] private SetUpInventoryContext contextProvider; 

    [SerializeField] private ItemUseContext context; 

    private void Start()
    {
        context = contextProvider.Context;
        Inventory.OnInventoryChanged += PresentInventory;
        PresentInventory();
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChanged += PresentInventory;
    }
    public override void PresentInventory()
    {
        ClearList();
        Item[] items = inventory.Items;
        //print("da");
        Dictionary<Item, int> dict = new Dictionary<Item, int>();

        foreach (var item in items)
        {
            if (item.isStackable)
            {
                List<Item> tempItems = new List<Item>();
                tempItems = dict.Keys.ToList();
                bool doesItExist = false;
                foreach (var tempItem in tempItems)
                {
                    if (tempItem.ItemName == item.ItemName)
                    {
                        dict[tempItem]++;
                        doesItExist = true;
                        break;
                    }
                }
                if (!doesItExist)
                {
                    dict.Add(item, 1);
                }

            }
            else
            {
                dict.Add(item, 1);
            }
        }

        List<Item> listWithItemsStacked = new List<Item>();
        listWithItemsStacked = dict.Keys.ToList();

        List<int> listWithQuantityForItems = new List<int>();
        listWithQuantityForItems = dict.Values.ToList();

        for (int i = 0; i < listWithItemsStacked.Count; i++)
        {
            ItemPresenter itemPresenter = Instantiate(itemPresenterPrefab);
            itemPresenter.transform.SetParent(listParent);
            itemPresenter.transform.SetParent(listParent);
            itemPresenter.transform.localScale = Vector3.one;
            TextMeshProUGUI textQuantity = itemPresenter.GetComponentInChildren<TextMeshProUGUI>();

            
            var iconPresenter = itemPresenter as IconViewItemPresenter;
            if (iconPresenter != null) 
            { 
                iconPresenter.Setup(listWithItemsStacked[i], context); 
            }
            itemPresenter.PresentItem(listWithItemsStacked[i]);
        }
        if (sortingStrategyNameText != null)
            sortingStrategyNameText.text = inventory.GetCurrentStrategyName();
    }

    private void ClearList()
    {
        foreach (Transform transform in listParent.GetComponentsInChildren<Transform>())
        {
            if (transform != listParent)
                Destroy(transform.gameObject);
        }
    }
}
