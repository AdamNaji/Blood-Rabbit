using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public List<NodeScript> NeighborsList;

    private void OnDrawGizmos()
    {
        foreach (var neighbour in NeighborsList)
        {
            Gizmos.DrawLine(transform.position, neighbour.transform.position);

            Gizmos.color = Color.blue;
        }
    }
}
