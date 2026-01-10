using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPUI : MonoBehaviour
{
    [SerializeField] private Image xpFill;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI xpText;

    public void UpdateUI(int level, int currentXP, int xpToNextLevel)
    {
        xpFill.fillAmount = (float)currentXP / xpToNextLevel;
        levelText.text = "Level " + level;
        xpText.text = currentXP + " / " + xpToNextLevel;
    }
}
