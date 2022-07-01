using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthPotionQuantity : MonoBehaviour
{
    public Inventory inventory;
    private void Update()
    {
        gameObject.GetComponent<Text>().text = ("x " + inventory.GetConsumiblePotions().Count);
    }
}
