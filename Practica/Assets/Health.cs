using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Health : MonoBehaviour
{
    public int health = 6;
    int maxHealth;
    public int numOfHearts = 3;

    bool canRevive = false;

    public List<Image> hearts = new List<Image>();
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Animator animator;

    private void Update()
    {
        if (health <= 0 && !canRevive)
        {
            SwampLevelManager.isInputEnabled = false;
            Physics2D.IgnoreLayerCollision(9, 12, true);
            animator.SetBool("isDead", true);
            animator.SetBool("isHurted", false);
            animator.SetBool("isSpikeHurted", false);
            SceneManager.LoadScene(3);
        } else if (health <= 0 && canRevive)
        {
            health = maxHealth;

            for (int i = 0; i < hearts.Count; i++)
            {
                hearts[i].sprite = fullHeart;
            }

            canRevive = false;
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void Start()
    {
        maxHealth = health;

        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void ReduceHealth(int damage)
    {
        int i = (health / 2) - 1;

        if (health % 2 == 0)
        {
            hearts[i].sprite = halfHeart;
        } else
        {
            hearts[i + 1].sprite = emptyHeart;
        }
        health -= damage;
    }

    public void IncreaseHealth(int healthPoints)
    {

        int i = (health / 2);

        if (health % 2 == 0)
        {
            hearts[i].sprite = halfHeart;
        }
        else
        {
            hearts[i].sprite = fullHeart;
        }
        health += healthPoints;
    }

    public void IncreaseMaxHealth(int newHeart){

        numOfHearts += newHeart;
        health = maxHealth + 2;
        for (int i = 0; i < numOfHearts; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        maxHealth = health;
    }

    public void SetRevive()
    {
        canRevive = true;
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetNumberOfHearts()
    {
        return numOfHearts;
    }
}
