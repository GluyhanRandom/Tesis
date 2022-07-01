using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CurrentMaxHealth : MonoBehaviour
{
    public Health playerHealth;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = ("x " + playerHealth.GetNumberOfHearts());
    }
}
