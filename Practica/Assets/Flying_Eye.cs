using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Flying_Eye : Enemy
{
    int maxHealth = 40;
    int currentHealth = 0;
    bool movingRight = false;
    public Animator animator;
    bool isFalling;

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    private void Awake()
    {
        SetMaxHealth(maxHealth);
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < -0.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
            if (animator.GetBool("isDead") == true)
            {
                animator.SetTrigger("isLanding");
            }
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        speed = 600;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public override void TakeDamage(int damage)
    {
        animator.SetBool("isHurted", true);
        currentHealth -= damage;
        speed = 0;
        if (currentHealth <= 0)
        {
            rb.gravityScale = 3;
            animator.SetBool("isDead", true);
        }
        StartCoroutine("Recover");
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(0.26f);
        animator.SetBool("isHurted", false); 
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
