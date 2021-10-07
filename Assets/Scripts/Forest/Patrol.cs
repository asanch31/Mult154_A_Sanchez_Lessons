using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrol : MonoBehaviour
{
    public List<GameObject> waypoints;
    private NavMeshAgent agent;
    private const float WP_TRESHOLD = 6.0f;
    private GameObject currentWP;
    private int currentWPIndex = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWP = GetNextWaypoint();
    }
    GameObject GetNextWaypoint()
    {
        currentWPIndex++;
        if (currentWPIndex == waypoints.Count)
        {
            currentWPIndex = 0;
        }
        print(waypoints[currentWPIndex]);
        return waypoints[currentWPIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
       if (Vector3.Distance(transform.position, currentWP.transform.position) < WP_TRESHOLD)
        {
            currentWP = GetNextWaypoint();
            agent.SetDestination(currentWP.transform.position);
            
        }
    }
}
