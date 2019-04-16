using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenShot : MonoBehaviour
{
    public float offset;
    public GameObject projectile;
    public Transform shotpoint;
    private float timeShot;
    public float startTime;
    private void Update()
    {
        Vector3 differsnce = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(differsnce.y, differsnce.x) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0f,0f,(rotZ+offset)/2);
        if(timeShot<=0)
        {       
             if (Input.GetMouseButtonDown(0))
             {
                 Instantiate(projectile, shotpoint.position, transform.rotation);
                 timeShot = startTime;
             }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
    }
}
