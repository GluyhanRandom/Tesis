using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BadKarmaText : MonoBehaviour
{
    public KarmaData karmaData;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = ("Bad Karma Points: " + karmaData.PlayerBadKarma);
    }
}
