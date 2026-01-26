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
    [SerializeField] private Volume hurtEffect;
    public StarterAssetsInputs starterAssetsInputs;
    
    private Vignette vignette;
    public event Action<DamageData,PlayerData> onHit;
    public event Action<int> onHeal;
    public event Action onDie;

    private void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();

        playerData.currentHP = playerData.maxHP;

        if (hurtEffect != null)
        {
            hurtEffect.profile.TryGet(out vignette);
        }
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
        if(vignette is not null)
        {
            StartCoroutine(HurtEffect());
        }
        
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

    private IEnumerator HurtEffect() 
    {
        vignette.intensity.value = 0.5f;
        yield return new WaitForSeconds(0.5f);
        vignette.intensity.value = 0f;
    }


}
