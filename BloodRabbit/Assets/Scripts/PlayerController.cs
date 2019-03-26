using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    [SerializeField] private float moveForce = 1.0f;

    private Rigidbody2D playerRigidbody2D;


    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();

    }


    void Update () {
       

        if (Input.GetButton("Right"))
        {
            playerRigidbody2D.AddForce(Vector3.right * moveForce * Time.deltaTime);

        }
         if (Input.GetButton("Left") )
        {
            playerRigidbody2D.AddForce(Vector3.left * moveForce * Time.deltaTime);
        }
       if (Input.GetButton("Up"))
        {
            playerRigidbody2D.AddForce(Vector3.up * moveForce * Time.deltaTime);

        }
         if (Input.GetButton("Down"))
        {
            playerRigidbody2D.AddForce(Vector3.down * moveForce * Time.deltaTime);
        }

    }

   
}
