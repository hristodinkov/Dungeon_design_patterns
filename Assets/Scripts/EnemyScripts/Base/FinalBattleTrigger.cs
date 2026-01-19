using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattleTrigger : MonoBehaviour
{
    public List<GameObject> gameObjectsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in gameObjectsToActivate)
        {
            obj.SetActive(true);
        }
    }

}
