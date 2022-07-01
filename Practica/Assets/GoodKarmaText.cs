using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoodKarmaText : MonoBehaviour
{
    public KarmaData karmaData;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = ("Good Karma Points: " + karmaData.PlayerGoodKarma);
    }
}
