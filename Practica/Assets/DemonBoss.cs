using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : Enemy
{
    int maxHealth = 500;
    int currentHealth = 0;

    public Transform player;
    bool isMovingRight = true;
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 2.5f;
    bool cantAttack = true;

    public GameObject attackPoint;

    public HealthBarScript healthBar;

    public GameObject choiceBox;

    private void Awake()
    {
        SetMaxHealth(maxHealth);
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("SetCanAttack", 2f, 3f);
    }

    public void Update()
    {

        if (player.transform.position.x < gameObject.transform.position.x && isMovingRight)
        {
            Flip();
        }
        if (player.transform.position.x > gameObject.transform.position.x && !isMovingRight)
        {
            Flip();
        }

        if (currentHealth > 0 && (Vector3.Distance(player.transform.position, rb.transform.position) > 9 || Vector3.Distance(player.transform.position, rb.transform.position) < 0))
        {
            animator.SetBool("Running", true);
            speed = 2.5f;
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

            rb.MovePosition(newPos);
            Invoke("ResetTriggers", 0f);
        }
        else
        {
            animator.SetBool("Running", false);
            speed = 0;
        }

        if (choiceBox.activeInHierarchy)
        {
            CaveLevelManager.isInputEnabled = false;
        }
    }

    void SetCanAttack()
    {
        cantAttack = true;
    }

    public void Attack()
    {
        if (cantAttack) {
            animator.SetTrigger("Attack");
        }
        Invoke("ResetTriggers", 0.5f);
    }

    public void EnableAttackCollider()
    {
        attackPoint.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        CaveLevelManager.spawnPortal = true;
    }

    void ResetTriggers()
    {
        animator.ResetTrigger("Attack");
        attackPoint.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        cantAttack = false;
    }

    void EnableChoiceBox()
    {
        choiceBox.SetActive(true);
        animator.speed = 0;
    }

    void Flip()
    {
        isMovingRight = !isMovingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        speed = 0;
        animator.SetTrigger("TakeHit");
        if (currentHealth <= 0)
        {
            speed = 0;
            healthBar.gameObject.SetActive(false);
            animator.SetBool("isDead", true);
        }
    }

    public override float GetCurrentHealth()
    {
        return currentHealth;
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
        return isMovingRight;
    }
}