using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathlessSeeking : MonoBehaviour
{

    Rigidbody rb;
   
    Vector3 desiredVelocity;
    Vector3 projectedPosition;
    public float projectedDistance;
    public float speed;
    public float BurstSpeed;
    float currentSpeed;
    public Transform target;
    Rigidbody targetRb;

    float dist;
    public float acceptableDistance;


    void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody>();
        targetRb = target.GetComponent<Rigidbody>();
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position);

        if (dist > acceptableDistance)
        {
            currentSpeed = speed;
            projectedPosition = target.position + (targetRb.velocity.normalized * projectedDistance);
            desiredVelocity = -speed * (target.transform.position - transform.position).normalized;

            rb.AddForce(desiredVelocity - rb.velocity);
        }
        else
        {
            speed = BurstSpeed;
            desiredVelocity = speed * (target.position - transform.position).normalized;
            rb.AddForce(desiredVelocity - rb.velocity);
        }

        Debug.DrawLine(transform.position, projectedPosition, Color.red);
        Debug.DrawLine(transform.position, target.position, Color.blue);
        Debug.DrawLine(transform.position, desiredVelocity * 10, Color.green);
    }
}
