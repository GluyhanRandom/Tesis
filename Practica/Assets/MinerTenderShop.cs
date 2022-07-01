using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerTenderShop : MonoBehaviour
{
    public GameObject minerShop;
    public GameObject interactionBox;

    private void Start()
    {
        minerShop.SetActive(false);
        interactionBox.SetActive(false);
    }

    private void Update()
    {
        if (!minerShop.activeInHierarchy)
        {
            CaveLevelManager.isInputEnabled = true;
        }
        else
        {
            CaveLevelManager.isInputEnabled = false;
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
