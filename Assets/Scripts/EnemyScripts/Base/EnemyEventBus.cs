using System;
using UnityEngine;

public static class EnemyEventBus 
{
    public static event Action<Enemy> OnEnemyDied; 
    public static void EnemyDied(Enemy enemy) 
    { 
        OnEnemyDied?.Invoke(enemy); 
    }
}
