using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    int maxHealth = 200;
    int currentHealth = 0;

    public Transform player;
    bool isMovingRight = true;
    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 2.5f;

    private IEnumerator coroutine;

    public GameObject attackPoint;
    public GameObject attackPoint2;
    public GameObject attackPoint3;

    public HealthBarScript healthBar;

    public GameObject choiceBox;

    private void Awake()
    {
        SetMaxHealth(maxHealth);
        healthBar.SetMaxHealth(maxHealth);
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

        if (currentHealth > 0 && (Vector3.Distance(player.transform.position, rb.transform.position) > 4 || Vector3.Distance(player.transform.position, rb.transform.position) < 0))
        {
            animator.SetBool("Running", true);
            speed = 2.5f;
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

            rb.MovePosition(newPos);
            Invoke("ResetTriggers",0f);
        }
        else
        {
            animator.SetBool("Running", false);
            speed = 0;
        }

        if (choiceBox.activeInHierarchy)
        {
            SwampLevelManager.isInputEnabled = false;
        }
    }

    public void ChooseAttack()
    {
        int index = Random.Range(1, 3);

        if (index == 1)
        {
            animator.SetTrigger("Attack");
        }
        else if (index == 2)
        {
            animator.SetTrigger("Attack2");
        }
        else if (index == 3)
        {
            animator.SetTrigger("Attack3");
        }

        Invoke("ResetTriggers", 0.5f);
    }

    public void EnableAttackCollider()
    {
        attackPoint.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void EnableAttack2Collider()
    {
        attackPoint2.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void EnableAttack3Collider()
    {
        attackPoint3.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    void ResetTriggers()
    {
        animator.ResetTrigger("Attack");
        attackPoint.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        animator.ResetTrigger("Attack2");
        attackPoint2.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        animator.ResetTrigger("Attack3");
        attackPoint3.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    void EnableChoiceBox()
    {
        choiceBox.SetActive(true);
        animator.speed = 0;
        SwampLevelManager.spawnPortal = true;
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
