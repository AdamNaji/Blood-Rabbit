using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    public float speed;
    public float lifeTime;

    private void Start()
    {
        Invoke("Destroy",lifeTime);
    }
    private void Update()
    {
        transform.Translate((transform.up*speed*Time.deltaTime));
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemies")&& !isEnemy)
        {   
            Destroy(other.gameObject);
        }
    }
}
