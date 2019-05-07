using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    [SerializeField]public List<NodeScript> NeighborsList;
    public bool hasBeenVisited = false;
    public bool isPath = false;
    public NodeScript cameFrom = null;
    public float curentcost = 0;
    private void OnDrawGizmos()
    {
        foreach (var neighbour in NeighborsList)
        {
            Gizmos.DrawLine(transform.position, neighbour.transform.position);

            Gizmos.color = Color.blue;
        }
    }
}
