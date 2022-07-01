using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : MonoBehaviour
{
    public GameObject interactionBox;

    private void Start()
    {
        interactionBox.SetActive(false);
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
