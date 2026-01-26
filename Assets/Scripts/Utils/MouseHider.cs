using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseHider : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private IconViewInventoryPresenter inventoryPresenter;
    
    
    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                inventory.SetActive(true);
                inventoryPresenter.gameObject.SetActive(true);
                Time.timeScale = 0f;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                inventory.SetActive(false);
                inventoryPresenter.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
