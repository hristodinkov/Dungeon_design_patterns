using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    private int killedEnemies;
    [SerializeField] private int killEnemyObjective;
    [SerializeField] private List<GameObject> doors;

    private void UpdateText()
    {
        if (killedEnemies < killEnemyObjective)
        {
            questText.text = "Quest: Kill " + killedEnemies + "/" + killEnemyObjective + " enemies";
        }
        else
        {
            foreach (var door in doors)
            {
                door.SetActive(false);
            }
            questText.text = "Quest: Find and slay the dragon";
        } 
    }
    private void OnEnable() 
    { 
        EnemyEventBus.OnEnemyDied += HandleEnemyDied; 
    }
    private void OnDisable() 
    { 
        EnemyEventBus.OnEnemyDied -= HandleEnemyDied; 
    }
    private void HandleEnemyDied(EnemyController enemyController) 
    { 
        killedEnemies++; 
        UpdateText(); 
    }
}
