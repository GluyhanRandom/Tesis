using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampLevelManager : MonoBehaviour
{
    public static bool isInputEnabled = true;
    public static bool isDead = false;
    public static bool spawnPortal;
    public GameObject portal;
    private static SwampLevelManager instance;
    public KarmaData karma;

    public Vector2 lastCheckPointPos;

    public static bool fungiQuestCompleted = false;
    public static bool canRepeatDialogue = true;

    private void Awake()
    {
        karma.Reset();
        Player_Invulnerability.invincible = false;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
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
