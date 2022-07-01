using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCollider : MonoBehaviour
{
    public Transform groundDetection;
    public Animator playerAnimator;
    public Player_Movement playerMovement;
    public float distance;
    private void Update()
    {
        int layer_mask = LayerMask.GetMask("Player");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layer_mask);

        if (groundInfo.collider == true)
        {
            playerAnimator.SetFloat("Speed", 0f);
            playerMovement.SetRunSpeed(0f);
            SwampLevelManager.isInputEnabled = false;
        }
    }

    public GameObject returnObject()
    {
        return this.gameObject;
    }
}
