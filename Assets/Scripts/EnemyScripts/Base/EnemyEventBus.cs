using System;
using UnityEngine;

public static class EnemyEventBus 
{
    public static event Action<EnemyController> OnEnemyDied; 
    public static void EnemyDied(EnemyController enemy) 
    { 
        OnEnemyDied?.Invoke(enemy); 
    }
}
