using NUnit.Framework;
using StarterAssets;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathChecker : PlayerObserver
{
    [SerializeField] private List<GameObject> gameObjectsToActivate;
    
    protected override void OnDie()
    {
        foreach (GameObject obj in gameObjectsToActivate)
        {
            obj.SetActive(true);
        }
        playerController.starterAssetsInputs.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

    }

    protected override void OnHeal(int healAmount)
    {
        //No implementation needed
    }

    protected override void OnHit(DamageData damageData, PlayerData playerData)
    {
        //No implementation needed
    }

}
