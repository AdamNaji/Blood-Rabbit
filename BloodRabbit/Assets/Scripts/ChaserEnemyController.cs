using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyController : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform playerPosition ;  
    GameObject[] nodes ;
    GameObject[] nodesVisited;
    int a ;
    float[] nodesDistance;
    private int positionBegin;
    private RoomScript roomScript;
    private Collider2D[] nodeInArea;

    void Update()
    {   
        Vector2 direction = playerPosition.position - transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, distance);
        if (hitInfo.collider.tag == "Player")
        {
            Debug.DrawLine(transform.position, hitInfo.point , Color.red);
            GetComponent<Rigidbody2D>().velocity = (playerPosition.position - transform.position).normalized * speed;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position +transform.right*distance, Color.cyan);

            Findpath();
        }
    }

    void Start()
    {
        
         nodeInArea= Physics2D.OverlapCircleAll(transform.position, 50, 8);
    
         roomScript = GetComponentInParent<RoomScript>();
         
         positionBegin = -1;
         nodes = GameObject.FindGameObjectsWithTag("Node");
         nodesVisited = new GameObject[nodes.Length];
         a = 0;
         nodesDistance = new float[nodes.Length];
         NewPath();

    }

    void NewPath()
    {
        for (int i = 0; i < nodesDistance.Length; i++)
        {
            nodesDistance[i] = -1;
        }
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] != null)
            {
                float distancePlayerToBegin = Vector2.Distance(transform.position, nodes[i].transform.position);
                nodesDistance[i] = distancePlayerToBegin;
            }
        }

        float minDistance = float.MaxValue;
        positionBegin = -1;
        for (int i = 0; i < nodesDistance.Length; i++)
        {
            if (nodesDistance[i] != -1)
            {
                if (minDistance > nodesDistance[i])
                {
                    minDistance = nodesDistance[i];
                    positionBegin = i;
                }
            }
        }
    }
    void Findpath()
    {

        if (positionBegin != -1)
        {
            if (Vector2.Distance(transform.position, nodes[positionBegin].transform.position) > 0.1f)
            {
                GetComponent<Rigidbody2D>().velocity = (nodes[positionBegin].transform.position - transform.position).normalized * speed;

            }
            else
            {
                nodesVisited[a] = nodes[positionBegin];
                a++;
                nodes[positionBegin] = null;
                NewPath();          
            }
        }
        else
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");           
            a = 0;
            nodesDistance = new float[nodes.Length];
            NewPath();
        }
        
    }
    
}
