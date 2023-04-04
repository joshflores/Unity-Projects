using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Boid))]
public class BoidContainerBehavior : MonoBehaviour
{

    private Boid boid;

    public float radius; // 0, lower boundary force? 

    public float boundaryForce;

    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        // Assuming position starts at 0, 0, you would need to do more math, add extra vector... etc. 
        if (boid.transform.position.magnitude > radius) { // bubble around it and if too far no, we want everything to move to center.
            boid.velocity += this.transform.position.normalized * (radius - boid.transform.position.magnitude) * boundaryForce /* Increases scale */ * Time.deltaTime; 
        }
    }
}
