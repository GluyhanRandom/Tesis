using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerQuest : MonoBehaviour
{
    public Chest[] chestsArray;
    bool chestsCollected = false;
    public Enemy[] enemiesArray;
    bool enemiesKilled = false;

    private void Update()
    {
        chestsArray = FindObjectsOfType<Chest>();
        enemiesArray = FindObjectsOfType<Enemy>();

        if (chestsArray.Length > 0) {
            for (int i = 0; i < chestsArray.Length; i++)
            {
                if (!chestsArray[i].isOpen)
                {
                    break;
                }
                chestsCollected = true;
            }
        } else
        {
            chestsCollected = true;
        }

        if (enemiesArray.Length == 1)
        {
            enemiesKilled = true;
        }

        if (enemiesKilled == true && chestsCollected == true)
        {
            CaveLevelManager.minerQuestCompleted = true;
        }
    }
}
