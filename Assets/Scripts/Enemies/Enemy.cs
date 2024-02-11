using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy stats
    [SerializeField] int health = 30;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int money = 5;

    //Waypoint for following the path
    Transform[] waypoints;
    int waypointIndex = 0;

    private void Update()
    {
        if (waypoints != null)
        {
            Move();
        }
    }

    public void SetPath(GameObject path)
    {
        Transform[] childTransforms = path.GetComponentsInChildren<Transform>();

        waypoints = new Transform[childTransforms.Length - 1];

        for (int i = 1; i < childTransforms.Length; i++)
        {
            waypoints[i - 1] = childTransforms[i];
        }

        transform.position = waypoints[waypointIndex].transform.position;
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


