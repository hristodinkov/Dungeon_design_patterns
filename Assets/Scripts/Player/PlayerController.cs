using StarterAssets;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BoxCollider attackCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerData playerData;

    public StarterAssetsInputs starterAssetsInputs;

    public event Action<DamageData,PlayerData> onHit;
    public event Action<int> onHeal;
    public event Action onDie;

    private void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();

        playerData.currentHP = playerData.maxHP;
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartCoroutine(Attack());
        }
    }

    public void Heal(int amount) 
    { 
        onHeal?.Invoke(amount); 
    }

    private System.Collections.IEnumerator Attack()
    {
        attackCollider.enabled = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f);
        attackCollider.enabled = false;
    }

    public void GetHit(DamageData damageData)
    {
        playerData.currentHP -= damageData.damage;
        
        
        if (playerData.currentHP < 1)
        {
            playerData.currentHP = 0;
            onHit?.Invoke(damageData, playerData);
            onDie?.Invoke();
        }
        else
        {
            onHit?.Invoke(damageData, playerData);
        }
    }

    


}
