using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pucks : MonoBehaviour
{

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set the mass and radius of the puck
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        // Apply a friction force to slow down the puck
        // if (rb.velocity.magnitude > 0f)
        // {
        //     Vector2 frictionForce = -rb.velocity.normalized * mass * Physics2D.gravity.magnitude * 0.1f;
        //     rb.AddForce(frictionForce);
        // }
    }
}
