using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]  List<GameObject> enemyList;

    public void rooom()
    {
        foreach (var enemy in enemyList)
        {
            enemy.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            foreach (var enemy in enemyList)
            {
                enemy.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D otherCol)
    {
        if (otherCol.CompareTag("Player"))
        {
            foreach (var enemy in enemyList)
            {
                enemy.SetActive(false);
            }
        }
    }
}
