using UnityEngine;

public class ChaserEnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2;

    private RoomScript roomScript;

    [SerializeField] private float minimumDistanceToNode;

    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private float speed;

    private NodeScript targetNode;
    private NodeScript currentNode;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();

        roomScript = GetComponentInParent<RoomScript>();

        targetNode = roomScript.GetNode(PlayerController.Instance.transform.position);
        currentNode = roomScript.GetNode(transform.position);
    }

    private void Update()
    {
      
        if (Physics2D.Linecast(PlayerController.Instance.transform.position, transform.position, wallLayer)) FindPath();

        else
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(PlayerController.Instance.transform.position.y - transform.position.y, PlayerController.Instance.transform.position.x - transform.position.x) * Mathf.Rad2Deg+90 , Vector3.forward);
            rigidbody2.velocity = (PlayerController.Instance.transform.position - transform.position).normalized * speed;
        }
    }

    void FindPath()
    {
        targetNode = roomScript.GetNode(PlayerController.Instance.transform.position);
        transform.rotation=Quaternion.AngleAxis(Mathf.Atan2(currentNode.transform.position.y-transform.position.y, currentNode.transform.position.x - transform.position.x)*Mathf.Rad2Deg+90,Vector3.forward);
        rigidbody2.velocity = (currentNode.transform.position - transform.position).normalized * speed;

        if (Vector2.Distance(currentNode.transform.position, transform.position) > minimumDistanceToNode) return;

        NodeScript returnNode = null;
        var maxDistance = float.MaxValue;

        foreach (var neighbour in currentNode.NeighborsList)
        {
            if (Vector2.Distance(targetNode.transform.position, neighbour.transform.position) > maxDistance) continue;

            maxDistance = Vector2.Distance(targetNode.transform.position, neighbour.transform.position);
            returnNode = neighbour;
        }

        currentNode = returnNode;
    }
}
