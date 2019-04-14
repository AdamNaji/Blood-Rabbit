using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Collider2D[] collider2;

    void Start()
    {
        collider2 = Physics2D.OverlapCircleAll(transform.position, 50);
    }

    void Update()
    {
        
    }
}
