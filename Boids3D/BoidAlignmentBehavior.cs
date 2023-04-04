using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BoidAlignmentBehavior : MonoBehaviour
{
    private Boid boid;

    public float radius;

    // Start is called before the first frame update
    void Start() {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update() {
        // Dont do this in a REAL SCENARIO LOL, you can have a data structure that tracks all boids in scene
        // and optimize to check for local objects, ex: Ock Trees????
        var boids = FindObjectsOfType<Boid>();

        var average = Vector3.zero;
        var found = 0;

        foreach (var boid in boids.Where(b => b != boid)) {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radius) {
                average += boid.velocity;
                found += 1;
            }
        }

        if (found > 0) {
            average = average / found;
            boid.velocity += Vector3.Lerp(boid.velocity, average, Time.deltaTime);
        }

    }
}
