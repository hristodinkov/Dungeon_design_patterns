using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HurtPlayerPresenter:PlayerObserver
{
    [SerializeField] private Volume hurtEffect;
    private Vignette vignette;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (hurtEffect != null)
        {
            hurtEffect.profile.TryGet(out vignette);
        }
    }
    protected override void OnDie()
    {
        //no implementation needed for now
    }

    protected override void OnHeal(int healAmount)
    {
        //no implementation needed for now
    }

    protected override void OnHit(DamageData damageData, PlayerData playerData)
    {
        if (vignette is not null)
        {
            StartCoroutine(HurtEffect());
        }
    }

    private IEnumerator HurtEffect()
    {
        vignette.intensity.value = 0.5f;
        yield return new WaitForSeconds(0.5f);
        vignette.intensity.value = 0f;
    }


}
