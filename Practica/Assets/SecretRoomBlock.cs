using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomBlock : MonoBehaviour
{
    public ChildBlockCollider leftCollider;

    public void OnChildCollision2DEntered(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
