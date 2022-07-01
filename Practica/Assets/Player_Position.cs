using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Position : MonoBehaviour
{
    SwampLevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<SwampLevelManager>();
        transform.position = levelManager.lastCheckPointPos;
    }
}
