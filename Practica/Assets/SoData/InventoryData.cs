using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryData : ScriptableObject
{
    [SerializeField]
    private int _playerHealth;
    [SerializeField]
    private int _playerDamage;
    [SerializeField]
    private List<Item> _playerPotions;
    [SerializeField]
    private float _playerGold;

    public int PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }

    public int PlayerDamage
    {
        get { return _playerDamage; }
        set { _playerDamage = value; }
    }

    public List<Item> PlayerPotions
    {
        get { return _playerPotions; }
        set { _playerPotions = value; }
    }

    public float PlayerGold
    {
        get { return _playerGold; }
        set { _playerGold = value; }
    }
}
