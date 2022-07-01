using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HealthPotion : Item
{
    public GameObject itemNameSpace;
    public GameObject itemCostSpace;
    public GameObject itemSpriteSpace;
    public GameObject itemDescriptionSpace;
    public Sprite itemSprite;

    string itemName = "Health Potion";
    int itemCost = 25;
    string itemDescription = "Consume to restore your health. It's tasty.";

    private void Awake()
    {
        itemNameSpace.GetComponent<Text>().text = GetItemName();
        itemCostSpace.GetComponent<Text>().text = "$ " + GetItemCost().ToString();
        itemSpriteSpace.GetComponent<Image>().sprite = GetItemSprite();
        itemDescriptionSpace.GetComponent<Text>().text = GetItemDescription();
        itemDescriptionSpace.SetActive(false);
    }

    public void OnMouseEnter()
    {
        itemDescriptionSpace.SetActive(true);
    }

    public void OnMouseExit()
    {
        itemDescriptionSpace.SetActive(false);
    }

    public override Sprite GetItemSprite()
    {
        return itemSprite;
    }

    public override string GetItemName()
    {
        return itemName;
    }

    public override int GetItemCost()
    {
        return itemCost;
    }

    public override string GetItemDescription()
    {
        return itemDescription;
    }
}
