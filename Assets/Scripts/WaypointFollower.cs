using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)      //1st vector used for position of currently active waypoint & second for moving platform
            //This statement means that if the current waypoint & platform are at very small distance then we can think that they are
            //colliding with each other and now it has to go towards the next waypoint
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)                       //It is used to make the platform reverse when it reaches the last index
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
