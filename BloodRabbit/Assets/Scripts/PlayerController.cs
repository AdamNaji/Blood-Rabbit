using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    [SerializeField] private float moveForce = 1.0f;

    private Rigidbody2D playerRigidbody2D;

    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();


    }


    void Update () {

        playerAnimator.SetFloat("VelocityX", playerRigidbody2D.velocity.x);
        playerAnimator.SetFloat("VelocityY", playerRigidbody2D.velocity.y);

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
