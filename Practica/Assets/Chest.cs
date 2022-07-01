using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public GameObject loot;
    public bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger("isOpen");
            isOpen = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger("isOpen");
            isOpen = true;
        }
    }

    void SpawnLoot()
    {
        loot.SetActive(true);
    }
}
