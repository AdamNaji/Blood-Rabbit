using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitio : MonoBehaviour
{
    private Transform camPos;
    private Transform player;
    public float xCam;
    public float yCam;
    public float xPlayer;
    public float yPlayer;

    void Start()
    {
        camPos = Camera.main.transform;
        player = FindObjectOfType<PlayerController>().transform;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camPos.transform.position += new Vector3(xCam, yCam, 0);
            player.transform.position += new Vector3(xPlayer,yPlayer,0);
        }

        
    }

   
}
    