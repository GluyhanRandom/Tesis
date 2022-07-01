using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<Mushroom>().OnChildTrigger2DEntered(collision);
    }

    public void ActivateCollider(bool activate)
    {
        if (activate)
        {
            Invoke("Reactivate", 1f);
        } else if (!activate)
        {
            gameObject.SetActive(false);
        }
    }

    void Reactivate()
    {
        gameObject.SetActive(true);
    }
}
