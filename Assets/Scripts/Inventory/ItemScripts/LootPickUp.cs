using InventorySystem;
using UnityEngine;

public class LootPickUp : MonoBehaviour
{
    public ItemData itemData; 
    public int amount = 1;
    private void OnTriggerEnter(Collider other)
    {
        PlayerContext ctx = other.GetComponent<PlayerContext>();
        if (ctx != null)
        {
            ctx.inventory.AddItem(new Item(itemData));
            Destroy(gameObject);
        }
    }

}
