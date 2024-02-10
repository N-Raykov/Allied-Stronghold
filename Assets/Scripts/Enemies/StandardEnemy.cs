using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    //Enemy stats
    [SerializeField] int health = 30;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int money = 5;

    //Waypoint for following the path
    [SerializeField] Transform[] waypoints;
    int waypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    //Moves towards next waypoint
    void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            Vector2 look = transform.InverseTransformPoint(waypoints[waypointIndex].transform.position);
            float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

            transform.Rotate(0, 0, angle);

            if (Vector2.Distance(transform.position, waypoints[waypointIndex].transform.position) <= 0.1f)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            Destroy(this);
        }
    }
}


