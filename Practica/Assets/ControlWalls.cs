using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWalls : MonoBehaviour
{
    public GameObject[] walls;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].SetActive(false);
            }
        }
    }
}
