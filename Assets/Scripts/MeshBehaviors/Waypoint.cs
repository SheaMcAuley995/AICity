using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{


    [SerializeField]
    bool DebugLines = true;
    [SerializeField]
    protected float _connectivityRadius = 50f;
    [SerializeField]
    protected float _debugDrawRadius = 10f;
    List<Waypoint> _connections;

    public void Start()
    {
        //Grab all waypoint objects in scene.
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        //Create a list of waypoints I can refer to later.
        _connections = new List<Waypoint>();

        //Check if they're a connected waypoint.
        for (int i = 0; i < allWaypoints.Length; i++)
        {
            Waypoint nextWaypoint = allWaypoints[i].GetComponent<Waypoint>();

            //i.e. we found a waypoint.
            if (nextWaypoint != null)
            {
                if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this)
                {
                    _connections.Add(nextWaypoint);
                }
            }
        }
    }

        public void OnDrawGizmos()
    {
        if(DebugLines)
        { 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _debugDrawRadius);

        

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
        }
    }

    public Waypoint NextWaypoint(Waypoint previousWaypoint)
    {
        if (_connections.Count == 0)
        {
            //No waypoints?  Return null and complain.
            Debug.LogError("Insufficient waypoint count.");
            return null;
        }
        else if (_connections.Count == 1 && _connections.Contains(previousWaypoint))
        {
            //Only one waypoint and it's the previous one? Just use that.
            return previousWaypoint;
        }
        else //Otherwise, find a random one that isn't the previous one.
        {
            Waypoint nextWaypoint;
            int nextIndex = 0;

            do
            {
                nextIndex = UnityEngine.Random.Range(0, _connections.Count);
                nextWaypoint = _connections[nextIndex];

            } while (nextWaypoint == previousWaypoint);

            return nextWaypoint;
        }
    }
}
