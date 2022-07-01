using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void TakeDamage(int damage);

    public abstract float GetCurrentHealth();

    public abstract void Die();

    public abstract void SetMaxHealth(int maxHealth);

    public abstract bool GetDirection();
}
