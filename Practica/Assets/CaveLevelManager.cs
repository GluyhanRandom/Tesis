using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveLevelManager : MonoBehaviour
{
    public static bool isInputEnabled = true;

    public GameObject portal;
    public static bool spawnPortal;

    public Vector2 lastCheckPointPos;

    public static bool minerQuestCompleted = false;
    public static bool canRepeatDialogue = true;

    public GameObject knightBoss;
    public GameObject knightHealthBar;

    public GameObject demonBoss;
    public GameObject demonHealthBar;

    public KarmaData karma;

    private void Awake()
    {
        if(karma.PlayerGoodKarma > karma.PlayerBadKarma)
        {
            knightBoss.SetActive(true);
            knightHealthBar.SetActive(true);
        } else
        {
            demonBoss.SetActive(true);
            demonHealthBar.SetActive(true);
        }
    }

    private void Update()
    {
        SpawnPortal();
    }

    public void SpawnPortal()
    {
        portal.SetActive(spawnPortal);
    }
}
