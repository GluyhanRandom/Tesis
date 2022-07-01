using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_Beast : Enemy
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bullet;
    int maxHealth = 180;
    int currentHealth = 0;
    float time = 0f;
    float reset = 2f;
    bool movingRight = false;
    public GameObject loot;

    private void Awake()
    {
        SetMaxHealth(maxHealth); 
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= reset)
        {
            animator.SetBool("canShoot", true);
            time = 0f;
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
        loot.transform.parent = null;
        loot.GetComponent<Collider2D>().enabled = true;
        loot.SetActive(true);
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

    public void Shoot()
    {
        if (GetDirection() == false)
        {
            bullet.transform.localScale = new Vector3(-7, 7, 0);
        }
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public void ResetShoot()
    {
        animator.SetBool("canShoot", false);
    }
}
