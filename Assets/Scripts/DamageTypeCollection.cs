using UnityEngine;

/// <summary>
/// Collection of all damage types defined in the game.
/// </summary>
[CreateAssetMenu(fileName = "DamageDataCollection", menuName = "Scriptable Objects/DamageDataCollection")]
public class DamageTypeCollection : ScriptableObject
{
    public DamageType[] damageTypes;
}
