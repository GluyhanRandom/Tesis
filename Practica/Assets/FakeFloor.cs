using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{
    public Player_Movement player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (player.GetCrouching() && collision.gameObject.layer == 9)
        {
            gameObject.SetActive(false);
        }
    }
}
