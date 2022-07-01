using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
/*    public Nightmare enemy1;
    Nightmare currentNightmare;
    public Hell_Beast enemy2;
    Hell_Beast currentHell_Beast;
    Vector2 whereToSpawn;
    Vector2 whereToSpawnSpecial;
    int originalQuantity;
    int currentQuantity;
    int portalCounter = 0;
    List<Enemy> enemigos = new List<Enemy>();

    void Awake()
    {   
        originalQuantity = Random.RandomRange(2, 3);
        currentQuantity = originalQuantity;
        for (int i = 0; i < originalQuantity; i++)
        {
            if (Random.RandomRange(0,10) % 2 == 0)
            {
                enemigos.Add(enemy1);
            }
            else {
                enemigos.Add(enemy2);
            }
        }
    }

    private void Update()
    {
        CheckSpawn();
        if (!areAnyEnemiesLeft())
        {
            if (portalCounter == 1) {
                LevelManager.spawnPortal = true;
            }
        }
    }

    // Update is called once per frame
    public void CheckSpawn()
    {
        if (currentQuantity > 0 && LevelManager.isCutsceneFinished && currentQuantity == originalQuantity)
        {
            SpawnEnemy();
            currentQuantity--;
        } else if (currentQuantity > 0 && LevelManager.isCutsceneFinished)
        {
            try
            {
                if (currentNightmare.GetCurrentHealth() == 0)
                {
                    SpawnEnemy();
                }
            }
            catch (System.Exception){}
            try
            {
                if (currentHell_Beast.GetCurrentHealth() == 0)
                {
                    SpawnEnemy();
                }
            }
            catch (System.Exception) {}
        }
    }

    void SpawnEnemy()
    {
        whereToSpawn = new Vector2(transform.position.x, transform.position.y);
        whereToSpawnSpecial = new Vector2(transform.position.x - 3, transform.position.y - 4);
        if (typeof(Hell_Beast).IsInstanceOfType(enemigos[currentQuantity - 1]))
        {
            currentHell_Beast = Instantiate(enemy2, whereToSpawnSpecial, Quaternion.identity);
        }
        else
        {
            currentNightmare = Instantiate(enemy1, whereToSpawn, Quaternion.identity);
        }
        currentQuantity--;
    }

    public bool areAnyEnemiesLeft()
    {
        try
        {
            if (currentQuantity <= 0 && currentNightmare.GetCurrentHealth() == 0)
            {
                portalCounter++;
                return false;
            }
        }
        catch (System.Exception) { }
        try
        {
            if (currentQuantity <= 0 && currentHell_Beast.GetCurrentHealth() == 0)
            {
                portalCounter++;
                return false;
            }
        }
        catch (System.Exception) { }

        return true;
    }
    */
}
