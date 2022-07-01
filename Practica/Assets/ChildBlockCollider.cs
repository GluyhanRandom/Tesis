using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBlockCollider : MonoBehaviour
{
    public SecretRoomBlock secretRoomBlock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        secretRoomBlock.OnChildCollision2DEntered(collision);
    }
}
