using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwordDamageText : MonoBehaviour
{
    public Player_Combat playerCombat;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = playerCombat.GetSwordDamage().ToString();
    }
}
