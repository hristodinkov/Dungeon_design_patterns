using IneventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace InventorySystem
{
    public class IconViewItemPresenter : ItemPresenter,IPointerClickHandler
    {
        public Image icon;
        private Item item;
        public TextMeshProUGUI itemQuantityText;
        private ItemUseContext context; 

        public override void PresentItem(Item itemToPresent)
        {
            //ClearItemInfo();
            //todo: implement this method to present the item as an icon
            //in the grid
            item = itemToPresent;
            icon.sprite = itemToPresent.itemIcon;
            UpdateStackCount();
            DisplayItemInfo();
        }

        private void UpdateStackCount()
        {
            if (item.IsStackable && item.Quantity > 1)
            {
                itemQuantityText.text = item.Quantity.ToString();
                itemQuantityText.gameObject.SetActive(true);
            }
            else
            {
                itemQuantityText.text = "";
                itemQuantityText.gameObject.SetActive(false);
            }
        }

        public void DisplayItemInfo()
        {
       
            if (item.Attack>0||item.Defense>0)
            {
                ItemInfoDisplayer.itemInfo = "Attack: " + item.Attack + "\n" + "Defense: " + item.Defense;
            }
            else if(item.HealAmount>0) 
            {
                ItemInfoDisplayer.itemInfo = "Heal: " + item.HealAmount; 
            }
            else 
            {
                ItemInfoDisplayer.itemInfo = "Quantity: "+ item.Quantity;
            }

            ItemInfoDisplayer.itemName = item.ItemName.ToString();
        }

        public void ClearItemInfo()
        {
            ItemInfoDisplayer.itemInfo = "";
        }

        public void Setup(Item item, ItemUseContext ctx)
        {
            this.item = item;     
            this.context = ctx;                               
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                UseItem action = UseItemCreator.Create(item);
                if (action != null && action.CanUse(item, context))
                {
                    action.Execute(item, context);
                }
            }
        }
    }


}

