using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public Health playerHealth;
    public Player_Combat playerCombat;
    List<Item> consumiblePotions = new List<Item>();
    Item[] weapons;
    Item[] armors;
    Item[] projectiles;
    float gold = 0f;

    public InventoryData inventoryData;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            playerHealth.IncreaseMaxHealth(inventoryData.PlayerHealth);
            playerCombat.IncreaseSwordMaxDamage(inventoryData.PlayerDamage);
            consumiblePotions = inventoryData.PlayerPotions;
            IncreaseGold(inventoryData.PlayerGold);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (playerHealth.GetCurrentHealth() < playerHealth.GetMaxHealth() && playerHealth.GetCurrentHealth() > 0 && consumiblePotions.Count > 0) {
                playerHealth.IncreaseHealth(1);
                consumiblePotions.RemoveAt(consumiblePotions.Count-1);
            }
        }

        inventoryData.PlayerGold = GetGold();
    }

    public void SetRevive()
    {
        playerHealth.SetRevive();
    }

    public void AddConsumiblePotions(int quantity)
    {
        HealthPotion potion = new HealthPotion();

        for (int i = 0; i < quantity; i++)
        {
            consumiblePotions.Add(potion);
        }

        inventoryData.PlayerPotions = GetConsumiblePotions();
    }

    public List<Item> GetConsumiblePotions()
    {
        return consumiblePotions;
    }

    public void SetObject(Item item)
    {
        if (GetGold() >= item.GetItemCost()) {
            if (typeof(HealthPotion).IsInstanceOfType(item))
            {
                consumiblePotions.Add(item);
                DecreaseGold(item.GetItemCost());
                inventoryData.PlayerPotions = GetConsumiblePotions();
            } else if (typeof(AttackUpgrade).IsInstanceOfType(item))
            {
                playerCombat.IncreaseSwordMaxDamage(7);
                DecreaseGold(item.GetItemCost());
                inventoryData.PlayerDamage = playerCombat.GetSwordDamage() - 20;
            } else if (typeof(HealthUpgrade).IsInstanceOfType(item))
            {
                if (playerHealth.GetMaxHealth() < 10) {
                    playerHealth.IncreaseMaxHealth(1);
                    DecreaseGold(item.GetItemCost());
                    inventoryData.PlayerHealth = playerHealth.GetNumberOfHearts() - 3;
                }
            }
        }
    }

    public void IncreaseGold(float incomingGold)
    {
        gold += incomingGold;
    }

    public void DecreaseGold(float cost)
    {
        gold -= cost;
    }

    public float GetGold()
    {
        return gold;
    }
}
