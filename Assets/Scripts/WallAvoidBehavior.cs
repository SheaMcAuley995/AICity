using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAvoidBehavior : MonoBehaviour {

    Rigidbody rb;

    public float avoidanceStrength;
    public float avoidanceRange;

    Vector3 wallDir;
	// Use this for initialization
	void Start () {
        wallDir = transform.forward;
        rb = GetComponent<Rigidbody>();

	}
	
    public void doWallAvoidance()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, wallDir, out hit, avoidanceRange))
        {
            rb.AddForce(hit.normal * avoidanceStrength);
        }
        else
        {
            Vector3 wallDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
	// Update is called once per frame
	void Update () {
        doWallAvoidance();
	}
}
