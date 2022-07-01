using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract Sprite GetItemSprite();

    public abstract string GetItemName();

    public abstract int GetItemCost();

    public abstract string GetItemDescription();
}
