using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem particleSystemHit;

    public Animator animator;
    public Player_Movement player_movement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Transform attackPoint2;
    public float attackRange2 = 0.5f;
    public Transform attackPoint3;
    public float attackRange3 = 0.5f;
    public Transform punchPoint;
    public float punchRange = 0.5f;
    public Transform punchPoint2;
    public float punchRange2 = 0.5f;
    public Transform punchPoint3;
    public float punchRange3 = 0.5f;
    public LayerMask enemyLayers;
    int attackDamage = 20;
    int punchDamage = 5;
    public Player_Movement playerMovement;
    List<string> animationList = new List<string>(new string[] {"isAttacking", "isAttacking2", "isAttacking3"});
    List<string> animationList2 = new List<string>(new string[] { "isPunching", "isPunching2", "isPunching3" });
    public int combonum;
    public float reset;
    public float resettime;

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0) && combonum < 3) {
                if (playerMovement.GetCurrentWeapon() == 0) {
                    animator.SetTrigger(animationList[combonum]);
                    combonum++;
                    reset = 0f;
                } else if (playerMovement.GetCurrentWeapon() == 1)
                {
                    animator.SetTrigger(animationList2[combonum]);
                    combonum++;
                    reset = 0f;
                }
            }
            if (combonum > 0)
            {
                reset += Time.deltaTime;
                if (reset > resettime)
                {
                    animator.SetTrigger("Reset");
                    combonum = 0;
                }
            }
            if (combonum == 3)
            {
                resettime = 3f;
                combonum = 0;
                animator.SetTrigger("Reset");
            }
            else
            {
                resettime = 1f;
                animator.SetTrigger("Reset");
            }
        
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        playerMovement.SetRunSpeed(8f);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<Enemy>().TakeDamage(attackDamage);
            particleSystemHit.Play();
            EnemyMovement(hitEnemies, i);
        }
    }

    public void Attack2()
    {
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2, enemyLayers);
        playerMovement.SetRunSpeed(8f);
        for (int i = 0; i < hitEnemies2.Length; i++)
        {
            hitEnemies2[i].GetComponent<Enemy>().TakeDamage(attackDamage);
            particleSystemHit.Play();
            EnemyMovement(hitEnemies2, i);
        }
    }

    public void Attack3()
    {
        Collider2D[] hitEnemies3 = Physics2D.OverlapCircleAll(attackPoint3.position, attackRange3, enemyLayers);
        playerMovement.SetRunSpeed(8f);
        for (int i = 0; i < hitEnemies3.Length; i++)
        {
            hitEnemies3[i].GetComponent<Enemy>().TakeDamage(attackDamage);
            particleSystemHit.Play();
            EnemyMovement(hitEnemies3, i);
        }
    }
    public void Punch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, enemyLayers);
        playerMovement.SetRunSpeed(8f);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<Enemy>().TakeDamage(punchDamage);
            EnemyMovement(hitEnemies, i);
        }
    }

    public void Punch2()
    {
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(punchPoint2.position, punchRange2, enemyLayers);
        playerMovement.SetRunSpeed(8f);
        for (int i = 0; i < hitEnemies2.Length; i++)
        {
            hitEnemies2[i].GetComponent<Enemy>().TakeDamage(punchDamage);
            EnemyMovement(hitEnemies2, i);
        }
    }

    public void Punch3()
    {
        Collider2D[] hitEnemies3 = Physics2D.OverlapCircleAll(punchPoint3.position, punchRange3, enemyLayers);
        playerMovement.SetRunSpeed(8f);
        for (int i = 0; i < hitEnemies3.Length; i++)
        {
            hitEnemies3[i].GetComponent<Enemy>().TakeDamage(punchDamage);
            EnemyMovement(hitEnemies3, i);
        }
    }

    private void EnemyMovement(Collider2D[] hitEnemies, int i)
    {
        if (hitEnemies[i].GetComponent<Enemy>().GetDirection())
        {
            if (typeof(Nightmare).IsInstanceOfType(hitEnemies[i].GetComponent<Enemy>()))
            {
                hitEnemies[i].GetComponent<Enemy>().GetComponent<Rigidbody2D>().AddForce(new Vector2(35f, 20f), ForceMode2D.Impulse);
            } else if (typeof(Flying_Eye).IsInstanceOfType(hitEnemies[i].GetComponent<Enemy>()))
            {
                hitEnemies[i].GetComponent<Enemy>().GetComponent<Rigidbody2D>().AddForce(new Vector2(15f, 5f), ForceMode2D.Impulse);
            }
        }
        else
        {
            if (typeof(Nightmare).IsInstanceOfType(hitEnemies[i].GetComponent<Enemy>()))
            {
                hitEnemies[i].GetComponent<Enemy>().GetComponent<Rigidbody2D>().AddForce(new Vector2(-35f, 10f), ForceMode2D.Impulse);
            }
            else if (typeof(Flying_Eye).IsInstanceOfType(hitEnemies[i].GetComponent<Enemy>()))
            {
                hitEnemies[i].GetComponent<Enemy>().GetComponent<Rigidbody2D>().AddForce(new Vector2(-15f, 5f), ForceMode2D.Impulse);
            }
        }
    }

    public void RecoverSpeed()
    {
        playerMovement.SetRunSpeed(30f);
    }

    public void LoseSpeed()
    {
        playerMovement.SetRunSpeed(8f);
    }

    public void IncreaseSwordMaxDamage(int extraSwordDamage)
    {
        attackDamage += extraSwordDamage;
    }

    public int GetSwordDamage()
    {
        return attackDamage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange3);

        Gizmos.DrawWireSphere(punchPoint.position, punchRange);
        Gizmos.DrawWireSphere(punchPoint2.position, punchRange2);
        Gizmos.DrawWireSphere(punchPoint3.position, punchRange3);
    }
}
