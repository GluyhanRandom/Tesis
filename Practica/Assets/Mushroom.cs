using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    float speed = 3;
    int maxHealth = 200;
    int currentHealth = 0;
    public bool movingRight = true;
    public ChildCollider enemyDetector;
    public Animator animator;
    public GameObject loot;

    private void Awake()
    {
        SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void OnChildTrigger2DEntered(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            enemyDetector.ActivateCollider(false);
            animator.SetBool("canAttack", true);
            speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 11)
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
        animator.SetBool("takeDamage", true);
        speed = 0;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("isDead");
        }
    }

    void ResetAttack()
    {
        animator.SetBool("canAttack", false);
        enemyDetector.ActivateCollider(true);
        speed = 3;
    }

    void ResetVelocity()
    {
        animator.SetBool("takeDamage", false);
        speed = 3;
    }
    
    public override void Die()
    {
        Destroy(gameObject);
        loot.transform.parent = null;
        loot.GetComponent<Collider2D>().enabled = true;
        loot.SetActive(true);
    }

    void Wait()
    {
        speed = 0;
        Invoke("Die", 2f);
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
