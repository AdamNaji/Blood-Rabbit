using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnerRoom : MonoBehaviour
{
    public int Direction; //1=Bas,2=Haut,3=Gauche,4=Droite

    private RoomTemplates templates;

    private int random;

    public bool spawned = false;
 
    private bool canCheck;
    

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.1f);
        Invoke("ToggleCheck",0.2f);
    }
    void Spawn()
    {
        
        //1=Bas,2=Haut,3=Gauche,4=Droite
        if (spawned == false)
        {
            if (Direction == 1)
            {
                random = Random.Range(0, templates.roomBas.Length);                
                GameObject room= Instantiate(templates.roomBas[random], transform.position, templates.roomBas[random].transform.rotation);
                templates.rooms.Add(room);
                spawned = true;
            }
            else if (Direction == 2)
            {
                random = Random.Range(0, templates.roomHaut.Length);
                GameObject room = Instantiate(templates.roomHaut[random], transform.position, templates.roomHaut[random].transform.rotation);
                templates.rooms.Add(room);

                spawned = true;
            }
            else if (Direction == 3)
            {
                random = Random.Range(0, templates.roomGauche.Length);
                GameObject room = Instantiate(templates.roomGauche[random], transform.position, templates.roomGauche[random].transform.rotation);
                templates.rooms.Add(room);
                spawned = true;
            }
            else if (Direction == 4)
            {
                random = Random.Range(0, templates.RoomDroite.Length);
                GameObject room = Instantiate(templates.RoomDroite[random], transform.position, templates.RoomDroite[random].transform.rotation);
                templates.rooms.Add(room);
                spawned = true;
            }

         }
        
    }

    void ToggleCheck()
    {
        canCheck = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
  
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<SpawnerRoom>())
            {
                if (!other.GetComponent<SpawnerRoom>().spawned && !spawned)
                {


                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);

                }

            }

            spawned = true;


        }

    }
}
