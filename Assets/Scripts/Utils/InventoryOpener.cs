using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryOpener : MouseHider
{
    private bool isInventoryOpen = false;
    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!isInventoryOpen)
            {
                isInventoryOpen = true;
                inventory.SetActive(true);
                inventoryPresenter.gameObject.SetActive(true);
                Time.timeScale = 0f;

            }
            else
            {
                isInventoryOpen = false;
                inventory.SetActive(false);
                inventoryPresenter.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
