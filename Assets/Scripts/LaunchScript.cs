using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    public float launchSpeed = 120f;
    public float launchAngle = 20;
   
    
    public float deltaTime = 0.02f;
    private float range = 0;
    public float gravity = 1.6f;
    private float timeTaken = 0.0f;

    public Vector3 velocity;
    public Vector3 gravityAcceleration;

    private bool hasLogged = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Launch");
            velocity = new Vector3(Mathf.Cos(launchAngle * Mathf.PI / 180) * launchSpeed, Mathf.Sin(launchAngle * Mathf.PI / 180) * launchSpeed);
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            gravityAcceleration = new Vector3(0.0f, -1.6f, 0.0f);

            
            Debug.DrawLine(transform.position, velocity, Color.red, 2);
        }

    }

    private void FixedUpdate()
    {

        transform.position = transform.position + velocity * deltaTime;

        velocity = velocity + gravityAcceleration * deltaTime;

       
        if (transform.position.y <= -1.0f && !hasLogged)
        {
            Range(velocity, launchAngle, gravity);
            TimeTaken(velocity, launchAngle, gravity);

            hasLogged = true;
        }

        Debug.DrawLine(transform.position, transform.position + velocity, Color.green);

    }

    void Range(Vector3 velocity, float angle, float gravity)
    {
        range = (velocity.sqrMagnitude * Mathf.Sin((2*angle * Mathf.PI) / 180))/gravity;
        Debug.Log("When the angle is " + launchAngle + " the range is: " + range);
    }

    void TimeTaken(Vector3 velocity, float angle, float gravity)
    {
        timeTaken = (2*velocity.magnitude * Mathf.Sin((angle * Mathf.PI) / 180)) / gravity;

        Debug.Log("Time taken to hit the ground: " + timeTaken);
    }
}
