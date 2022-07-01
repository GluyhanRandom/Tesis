using System.Collections;
using System.Collections.Generic;
using MathNet.Numerics;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject floor;
    public GameObject platformv;
    public GameObject platformh;
    public GameObject spikes;
    public GameObject fragilePlatform;
    public GameObject climbingPlatform;
    public GameObject slimeBoss;
    public GameObject chest;
    public GameObject enemy;
    public KarmaData karmaData;
    LayerMask extraFloor = 18;
    LayerMask chestFloor = 19;

    private void Start()
    {
        if (gameObject.layer == 18)
        {
            Instantiate(floor, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        } else if (gameObject.layer == 21)
        {
            Instantiate(platformv, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        } else if (gameObject.layer == 22)
        {
            Instantiate(platformh, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        } else if (gameObject.layer == 15)
        {
            Instantiate(spikes, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        } else if (gameObject.layer == 23)
        {
            Instantiate(fragilePlatform, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        } else if (gameObject.layer == 24)
        {
            Instantiate(climbingPlatform, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        } else if (gameObject.layer == 25)
        {
            float probability = Random.Range(0.0f, 1.0f);

            if (karmaData.PlayerGoodKarma > karmaData.PlayerBadKarma)
            {
                if (probability <= 0.8f)
                {
                    Instantiate(chest, transform.position, Quaternion.identity);
                } else if (probability > 0.2f)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity);
                }
            } else if (karmaData.PlayerGoodKarma <= karmaData.PlayerBadKarma)
            {
                if (probability <= 0.8f)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity);
                }
                else if (probability > 0.8f)
                {
                     Instantiate(chest, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
