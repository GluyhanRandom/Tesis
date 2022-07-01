using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public List<GameObject> doors;

    private void Start()
    {
        for (int i = 0; i <= doors.Count; i++)
        {
            doors[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            Destroy(collision.gameObject);
        }
    }
}
