using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public DamageData CurrentDamage { get; private set; }
    [SerializeField] private GameObject currentWeaponModel;
    public Transform weaponHolder;
    [SerializeField] private Transform lastWeapon;
    public void SetWeaponDamage(DamageData data) 
    { 
        CurrentDamage = data;
    }
    public void SetWeaponModel(GameObject prefab)
    {
        if (currentWeaponModel != null)
            Destroy(currentWeaponModel);
        currentWeaponModel = Instantiate(prefab, weaponHolder);

        currentWeaponModel.transform.localPosition = lastWeapon.localPosition;
        currentWeaponModel.transform.localRotation = lastWeapon.localRotation;
        currentWeaponModel.transform.localScale = lastWeapon.localScale;

        lastWeapon = currentWeaponModel.transform;
    }
}
