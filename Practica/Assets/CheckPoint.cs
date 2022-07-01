using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SwampLevelManager levelManager;
    private CaveLevelManager levelManager1;

    private void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<SwampLevelManager>();
        levelManager1 = GameObject.FindWithTag("LevelManager").GetComponent<CaveLevelManager>();

        if (levelManager != null)
        {
            levelManager.lastCheckPointPos = transform.position;
        } else if (levelManager1 != null)
        {
            levelManager1.lastCheckPointPos = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (levelManager != null) {
                levelManager.lastCheckPointPos = transform.position;
            } else if (levelManager1 != null)
            {
                levelManager1.lastCheckPointPos = transform.position;
            }
        }
    }
}
