using UnityEngine;

public class ResetManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        playerData.ResetToInitial();
    }
}

