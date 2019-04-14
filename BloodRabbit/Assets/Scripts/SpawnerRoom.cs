using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnerRoom : MonoBehaviour
{
    public int Direction; //1=Bas,2=Haut,3=Gauche,4=Droite

    private RoomTemplates templates;

    private int random;

    private int nbRoom;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.1f);
    }
    void Spawn()
    {
        for(nbRoom=0;nbRoom<50;nbRoom++)
        if (spawned == false)
        {
            if (Direction == 1)
            {
                random = Random.Range(0, templates.roomBas.Length);
                Instantiate(templates.roomBas[random], transform.position, templates.roomBas[random].transform.rotation);
            }
            else if (Direction == 2)
            {
                random = Random.Range(0, templates.roomHaut.Length);
                Instantiate(templates.roomHaut[random], transform.position, templates.roomHaut[random].transform.rotation);
            }
            else if (Direction == 3)
            {
                random = Random.Range(0, templates.roomGauche.Length);
                Instantiate(templates.roomGauche[random], transform.position, templates.roomGauche[random].transform.rotation);
            }
            else if (Direction == 4)
            {
                random = Random.Range(0, templates.RoomDroite.Length);
                Instantiate(templates.RoomDroite[random], transform.position, templates.RoomDroite[random].transform.rotation);
            }

            spawned = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<SpawnerRoom>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            }

            spawned = true; 
        }
        
    }
}
