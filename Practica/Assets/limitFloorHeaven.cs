using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitFloorHeaven : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = new Vector3(-4.5f, 52.2f, -1f);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
