using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public NodeScript[] nodesInRoom;

    void Start()
    {
        nodesInRoom = GetComponentsInChildren<NodeScript>();
    }

    void Update()
    {
        
    }
}
