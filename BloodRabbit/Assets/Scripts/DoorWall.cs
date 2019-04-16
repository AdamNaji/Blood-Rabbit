using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorWall : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("WallDoor"))
        {

            Destroy(other.gameObject);
                
        }

    }
}
