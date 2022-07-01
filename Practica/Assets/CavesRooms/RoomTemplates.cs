using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> rooms;

    int roomQuantity;

    private void Start()
    {
        roomQuantity = Random.Range(6, 11);
    }

    public int GetRoomQuantity()
    {
        return roomQuantity;
    }

    public void LessRoom()
    {
        roomQuantity -= 1;
    }
}
