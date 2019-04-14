using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject laser;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 direction = Vector2.up;
    // Start is called before the first frame update
    void Start()
    {

        RaycastHit2D raycast = Physics2D.Raycast(transform.position, direction);
        if (raycast.distance > 0)
        {
            laser = Instantiate(prefab, new Vector2(transform.position.x + direction.x * raycast.distance / 2, transform.position.y + direction.y * raycast.distance / 2), Quaternion.identity, transform);
            if (direction.x == 0)
            {
                laser.transform.localScale = new Vector3(laser.transform.localScale.x, raycast.distance * laser.transform.localScale.y);
            }
            else
            {
                laser.transform.localScale = new Vector3(laser.transform.localScale.x * raycast.distance, laser.transform.localScale.y);

            }
        }


        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Shot()
    {
        for (int i = 0; i < 10000; i++)
        {
            yield return new WaitForSeconds(2);
            laser.SetActive(true);
            yield return new WaitForSeconds(1);
            laser.SetActive(false);
        }
    }
}
