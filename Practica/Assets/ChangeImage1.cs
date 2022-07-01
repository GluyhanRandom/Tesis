using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeImage1 : MonoBehaviour
{

    public Sprite normalSprite;
    public Sprite transparentSprite;
    public Player_Movement playerWeapon;

    public void Update()
    {
        int currentWeapon = playerWeapon.GetCurrentWeapon();
        switch (currentWeapon)
        {
            case 0:
                GetComponent<Image>().sprite = transparentSprite;
                break;
            case 1:
                GetComponent<Image>().sprite = normalSprite;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}