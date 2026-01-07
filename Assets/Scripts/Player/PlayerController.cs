using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BoxCollider attackCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerData playerData;

    public event Action<DamageData,PlayerData> onHit;
    public event Action<int> onHeal;

    private void Start()
    {
        playerData.currentHP = playerData.maxHP;
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartCoroutine(EnableAttackCollider());
        }
    }

    public void Heal(int amount) 
    { 
        onHeal?.Invoke(amount); 
    }

    private System.Collections.IEnumerator EnableAttackCollider()
    {
        attackCollider.enabled = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f);
        attackCollider.enabled = false;
    }

    public void GetHit(DamageData damageData)
    {
        playerData.currentHP -= damageData.damage;
        if (playerData.currentHP < 0)
        {
            playerData.currentHP = 0;
        } 
        onHit?.Invoke(damageData,playerData);
    }


}
