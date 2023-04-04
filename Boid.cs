using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

    public Vector3 velocity;

    public float maxVelocity;


    // Start is called before the first frame update
    void Start()
    {
        // All boids start at max speed and go from there, you can also make them start at 0... see what happens ?
        velocity = this.transform.forward * maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {

        if (velocity.magnitude > maxVelocity) {
            velocity = velocity.normalized * maxVelocity;
        }
        
        // If we're moving in some direction, if we have velocity of 10 in a direction were gonna move 10 units every second, (give or take and frame)
        this.transform.position += velocity * Time.deltaTime;
        this.transform.rotation = Quaternion.LookRotation(velocity);
    }
}
