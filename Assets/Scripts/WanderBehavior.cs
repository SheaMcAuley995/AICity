using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MonoBehaviour {

    public float speed;
    public float radius;
    public float jitter;
    public float distance;
    public Vector3 target;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;

        target.z = target.y;
        target += transform.position;
        target += transform.forward * distance;

        target.y = 0;
        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredVelocity = dir * speed;

        rb.AddForce(desiredVelocity - rb.velocity);
        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        Debug.DrawLine(transform.position, transform.position + (transform.forward * distance), Color.red);
	}
}
