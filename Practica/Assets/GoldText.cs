using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoldText : MonoBehaviour
{
    public GameObject inventory;
    Inventory inventory1;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory1 = inventory.GetComponent<Inventory>();
    }

    private void Update()
    {
        gameObject.GetComponent<Text>().text = ("$ "+inventory1.GetGold());
    }
}
