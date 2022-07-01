using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValkyQuest : MonoBehaviour
{
    public Flying_Eye[] totalEyes;
    bool eyesKilled = false;

    private void Update()
    {
        totalEyes = Resources.FindObjectsOfTypeAll<Flying_Eye>();

        if (totalEyes.Length == 0)
        {
            eyesKilled = true;
        }

        if (eyesKilled == true && eyesKilled == true)
        {
            HeavenLevelManager.valkyQuestCompleted = true;
        }
    }
}
