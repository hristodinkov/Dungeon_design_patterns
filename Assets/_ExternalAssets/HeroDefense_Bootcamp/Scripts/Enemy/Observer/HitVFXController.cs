using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// An enemy observer that plays VFX whenever the enemy is hit based on the DamageType. 
/// </summary>
public class HitVFXController : EnemyObserver
{
    [SerializeField]
    private DamageTypeCollection damageTypeCollection; // A collection of all possible damage types and their associated VFX prefabs

    private Dictionary<DamageType, ParticleSystem> vfxDictionary = new Dictionary<DamageType, ParticleSystem>(); // Stores instantiated VFX per damage type
    private ParticleSystem vfxPlaying; // Tracks the currently playing VFX (not used yet, but could be used to control playback)

    /// <summary>
    /// Unity Start method. Initializes the VFX dictionary when the object is created.
    /// </summary>
    void Start()
    {
        BuildVFXDctionary();
    }

    /// <summary>
    /// Instantiates VFX prefabs for each damage type and stores them in the dictionary.
    /// Each VFX is parented to this GameObject and placed at the origin.
    /// </summary>
    private void BuildVFXDctionary()
    {
        foreach (DamageType damageType in damageTypeCollection.damageTypes)
        {
            ParticleSystem particleSystem = Instantiate(damageType.VFX); // Instantiate the VFX prefab
            particleSystem.transform.SetParent(transform);               // Parent to this GameObject
            particleSystem.transform.localPosition = Vector3.zero;      // Reset position relative to parent
            vfxDictionary.Add(damageType, particleSystem);              // Add to dictionary
        }
    }

    protected override void OnEnemyCreated(Enemy enemy)
    {
        // No implementation needed for now
    }

    /// <summary>
    /// Called when an enemy is hit.
    /// Plays the corresponding hit VFX based on the damage type.
    /// Special handling is added for debuff-type effects (like slowDown).
    /// </summary>
    protected override void OnEnemyHit(Enemy enemy, DamageData damageData)
    {
        if (damageData.damageType != null)
        {
            // If it's a debuff (e.g., slow), only play the VFX if it's not already playing
            if (damageData.slowDown > 0)
            {
                if (!vfxDictionary[damageData.damageType].isPlaying)
                    vfxDictionary[damageData.damageType].Play();
            }
            else
            {
                // Play the VFX for the given damage type
                vfxDictionary[damageData.damageType].Play();
            }
        }
    }

    protected override void OnEnemyDie(Enemy enemy)
    {
        // No implementation needed for now
    }
}
