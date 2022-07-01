using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public int openSide;
    public GameObject wall;

    RoomTemplates roomTemplates;
    private int rand;
    private bool spawned = false;

    private void Awake()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        if (wall != null)
        {
            wall.SetActive(false);
        }
        Invoke("Spawn", Random.Range(1, 3));
    }

    void Spawn()
    {
        if (roomTemplates.GetRoomQuantity() == 1)
        {
            Instantiate(roomTemplates.topRooms[21], transform.position, roomTemplates.topRooms[21].transform.rotation);
            roomTemplates.rooms.Add(roomTemplates.topRooms[21]);
            spawned = true;
            roomTemplates.LessRoom();
        }
        else if (roomTemplates.GetRoomQuantity() == 0 && (openSide == 2 || openSide == 3 || openSide == 4))
        {
            Instantiate(roomTemplates.topRooms[22], transform.position, roomTemplates.topRooms[22].transform.rotation);
            roomTemplates.rooms.Add(roomTemplates.topRooms[22]);
            spawned = true;
            roomTemplates.LessRoom();
        }

        if (spawned == false && roomTemplates.GetRoomQuantity() > 1 )
        { 
            if (openSide == 2)
            {
                rand = Random.Range(0, roomTemplates.topRooms.Length - 2);
                Instantiate(roomTemplates.topRooms[rand], transform.position, roomTemplates.topRooms[rand].transform.rotation);
                roomTemplates.rooms.Add(roomTemplates.topRooms[rand]);
            }
            else if (openSide == 3)
            {
                rand = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[rand], transform.position, roomTemplates.rightRooms[rand].transform.rotation);
                roomTemplates.rooms.Add(roomTemplates.rightRooms[rand]);
            }
            else if (openSide == 4)
            {
                rand = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[rand], transform.position, roomTemplates.leftRooms[rand].transform.rotation);
                roomTemplates.rooms.Add(roomTemplates.leftRooms[rand]);
            }
            spawned = true;
            roomTemplates.LessRoom();
        }
        CheckWalls();
    }

    void CheckWalls()
    {
        if (wall != null && !spawned)
        {
            wall.SetActive(true);
        }
        else
        {
            if (openSide != 1) {
                Destroy(gameObject);
            }
            else
            {
                wall.SetActive(true);
            }
        }
    }
}
