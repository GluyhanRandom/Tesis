using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenLevelManager : MonoBehaviour
{
    public static bool canRepeatDialogue = true;
    public static bool valkyQuestCompleted = false;

    static AstarPath[] pathFinder;

    public static void SpawnPathFinder()
    {
        pathFinder = Resources.FindObjectsOfTypeAll<AstarPath>();
        pathFinder[0].gameObject.SetActive(true);
    }
}
