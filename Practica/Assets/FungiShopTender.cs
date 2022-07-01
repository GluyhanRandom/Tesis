using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungiShopTender : MonoBehaviour
{

    public GameObject fungiShop;
    public GameObject interactionBox;

    private void Start()
    {
        fungiShop.SetActive(false);
        interactionBox.SetActive(false);
    }

    private void Update()
    {
        if (!fungiShop.activeInHierarchy)
        {
            SwampLevelManager.isInputEnabled = true;
        } else
        {
            SwampLevelManager.isInputEnabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            interactionBox.SetActive(false);
        }
    }
}
