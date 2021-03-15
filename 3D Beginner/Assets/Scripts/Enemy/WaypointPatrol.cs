using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    // Array of waypoints that ghosts should patrol
    public Transform[] waypoints;
    // Start is called before the first frame update

    // Store the current index of the waypoint array
    int m_CurrentWaypointIndex;

    void Start ()
    {
        // Initial target of Nav Mesh Agent
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update ()
    {
        /* 
         * Compare whether the remaining distance to the target 
         * is less than the stopping distance previously set in the Inspector window
         */
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            // Make sure the index is less than the length of array
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
