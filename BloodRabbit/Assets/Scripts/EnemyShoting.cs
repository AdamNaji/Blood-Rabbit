using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(Instantiate(projectile, transform.position,Quaternion.Euler(0,0,transform.rotation.eulerAngles.z/2)*Quaternion.Euler(0,0,45)));
            yield return new WaitForSeconds(1);
        }
    }
}
