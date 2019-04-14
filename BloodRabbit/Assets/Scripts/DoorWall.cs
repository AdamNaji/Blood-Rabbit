using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

       
            Destroy(other.gameObject);
        
    }
}
