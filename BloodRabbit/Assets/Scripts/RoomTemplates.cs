using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] roomBas;
    public GameObject[] roomHaut;
    public GameObject[] roomGauche;
    public GameObject[] RoomDroite;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedLastRoom;
    public GameObject LastRoom;

    void SpawnLastRoom()
    {
        Instantiate(LastRoom, rooms[rooms.Count - 1].transform.position,Quaternion.identity);
    }

    void Awake()
    {
        //Random.InitState(6);
        
    }
    void Start()
    {
        Invoke("SpawnLastRoom",waitTime);
    }
}
