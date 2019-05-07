using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    public GameObject projectile;
    private float shotRate;
    public float startShotRate;
    void Start()
    {      
       shotRate = startShotRate;
    }

    void Update()
    {
        if (shotRate <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotRate = startShotRate;
        }
        else
        {
            shotRate -= Time.deltaTime;
        }
    }
}
/*private IEnumerator Shooting()
{
    while (true)
    {
        Instantiate(Instantiate(projectile, transform.position,Quaternion.Euler(0,0,transform.rotation.eulerAngles.z/2)*Quaternion.Euler(0,0,45)));
        yield return new WaitForSeconds(1);
    }
}
}*/
