using System.Collections.Generic;
using System.Linq;
//using UnityEditor;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public List<NodeScript> NodesInRoom;

    private void Start()
    {
        NodesInRoom = GetComponentsInChildren<NodeScript>().ToList();


        foreach (var node in NodesInRoom)
        {
            foreach (var possibleNeighbour in NodesInRoom)
            {
                if (node == possibleNeighbour) continue;
                if (Physics2D.Linecast(node.transform.position, possibleNeighbour.transform.position)) continue;

                node.NeighborsList.Add(possibleNeighbour);
                
            }
        }
    }

    public NodeScript GetNode(Vector2 target)
    {
        NodeScript returnNode = null;
        var maxValue = float.MaxValue;

        foreach (var node in NodesInRoom)
        {

            if (Vector2.Distance(target, node.transform.position) > maxValue) continue;
            maxValue = Vector2.Distance(target, node.transform.position);
            returnNode = node;
        }

        return returnNode;
    }
}