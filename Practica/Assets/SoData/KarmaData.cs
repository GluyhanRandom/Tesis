using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class KarmaData : ScriptableObject
{
    [SerializeField]
    private double _playerGoodKarma;
    [SerializeField]
    private double _playerBadKarma;

    public double PlayerGoodKarma
    {
        get { return _playerGoodKarma; }
        set { _playerGoodKarma = value; }
    }

    public double PlayerBadKarma
    {
        get { return _playerBadKarma; }
        set { _playerBadKarma = value; }
    }

    public void Reset()
    {
        _playerBadKarma = 0;
        _playerGoodKarma = 0;
    }
}
