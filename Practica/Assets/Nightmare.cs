using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : Enemy
{
    float speed = 8;
    float distance = 20;
    int maxHealth = 100;
    int currentHealth = 0;
    bool movingRight = false;
    public Transform groundDetection;

    private void Awake()
    {
        SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        int layer_mask = LayerMask.GetMask("InvisibleWall");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layer_mask);

        if (groundInfo.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void SetMaxHealth(int maxHealth)
    {
        currentHealth = this.maxHealth;
    }

    public override bool GetDirection()
    {
        return movingRight;
    }

    public override float GetCurrentHealth()
    {
        return currentHealth;
    }
}
