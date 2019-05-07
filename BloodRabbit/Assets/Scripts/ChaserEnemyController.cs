using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChaserEnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2;

    private RoomScript roomScript;

    [SerializeField] private float minimumDistanceToNode;

    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private float speed;

    private List<Vector2> path;

    private int indexPath ;

    private NodeScript targetNode;

    private NodeScript startNode;

    private bool debug = false;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        path = new List<Vector2>();
        roomScript = GetComponentInParent<RoomScript>();   
    }

    private void Update()
    {


        if (Physics2D.Linecast(PlayerController.Instance.transform.position, transform.position + Vector3.right*0f, wallLayer))
            
        {  
            FindPath();
        }
        
        else 
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(PlayerController.Instance.transform.position.y - transform.position.y,
            PlayerController.Instance.transform.position.x - transform.position.x) * Mathf.Rad2Deg+90 , Vector3.forward);
            rigidbody2.velocity = (PlayerController.Instance.transform.position - transform.position).normalized * speed;
            path = new List<Vector2>();
        }
    }

    private void djikstra()
    {
        targetNode = roomScript.GetNode(PlayerController.Instance.transform.position);
        startNode = roomScript.GetNode(transform.position);
        List<NodeScript>openList = new List<NodeScript>{startNode};
        List<NodeScript> closedList = new List<NodeScript> ();
        while (openList.Count > 0)
        {
            openList = openList.OrderBy(x => x.curentcost).ToList();
            NodeScript currentNode = openList[0];
            openList.RemoveAt(0);
            currentNode.hasBeenVisited = true;
            closedList.Add(currentNode);
            
           
                foreach (var currentNodeNeighbour in currentNode.NeighborsList)
                {
                    float newcost = currentNode.curentcost + Vector2.Distance(currentNode.transform.position,currentNodeNeighbour.transform.position)
                                                           +Vector2.Distance(targetNode.transform.position,currentNodeNeighbour.transform.position);
                    if (currentNodeNeighbour.curentcost == 0 && currentNodeNeighbour != startNode ||
                        currentNodeNeighbour.curentcost > newcost)
                    {
                        currentNodeNeighbour.cameFrom = currentNode;
                        currentNodeNeighbour.curentcost = newcost;
                        openList.Add(currentNodeNeighbour);
                    }
                }
                   
        }

        path = new List<Vector2>();
            {
                NodeScript currentNode = targetNode;
                while (currentNode.cameFrom != null)
                {
                    path.Add(currentNode.transform.position);
                    currentNode.isPath=true;

                    currentNode = currentNode.cameFrom;

                
                }
                path.Add(currentNode.transform.position);
                path.Reverse();

            }
        foreach (var nodesss in roomScript.NodesInRoom)
        {
            nodesss.curentcost = 0;
            nodesss.cameFrom = null;
            nodesss.hasBeenVisited = false;
            nodesss.isPath = false;
        }

    }
    void FindPath()
    {
      

        if (path.Count>indexPath&&indexPath>=0)
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(path[indexPath].y - transform.position.y, path[indexPath].x - transform.position.x) * Mathf.Rad2Deg + 90, Vector3.forward);
            rigidbody2.velocity = (path[indexPath] - (Vector2)transform.position).normalized * speed;
            
            if (Vector2.Distance(path[indexPath], transform.position) < 0.1)
            {
                indexPath++;
            }
        }
        else
        {
            targetNode = roomScript.GetNode(PlayerController.Instance.transform.position);
            djikstra();
            indexPath = 0;
        }
       // Debug.Log(indexPath+",❤ "+path[indexPath]);
    }

    void OnDrawGizmos()
    {
        
        List<NodeScript> nodes = roomScript.NodesInRoom;
        if (nodes == null) return;

        foreach (NodeScript node in nodes)
        {
            if (node == null) continue;
            Gizmos.color =  Color.red;
            if (node.hasBeenVisited)
            {
                Gizmos.color = Color.yellow;
            }
            if (node.isPath)
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawWireSphere(node.transform.position+Vector3.back, 0.1f);

            foreach (NodeScript nodeNeighbor in node.NeighborsList)
            {
                Gizmos.DrawLine(node.transform.position, nodeNeighbor.transform.position);
            }
        }
    }
}
