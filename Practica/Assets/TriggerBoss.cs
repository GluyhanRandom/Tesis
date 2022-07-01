using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{

    public GameObject healthBar;
    public GameObject boss;
    int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && i == 0)
        {
            healthBar.SetActive(true);
            boss.SetActive(true);
            i++;
        }
    }
}
