using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungiQuest : MonoBehaviour
{
    public GameObject collectedGold;
    public GameObject firstEnemy;
    public GameObject secondEnemy;
    public GameObject thirdEnemy;

    private void Update()
    {
        if (collectedGold == null && firstEnemy == null && secondEnemy == null && thirdEnemy == null)
        {
            SwampLevelManager.fungiQuestCompleted = true;
        }
    }
}
