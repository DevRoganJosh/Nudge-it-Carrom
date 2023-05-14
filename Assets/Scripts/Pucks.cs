using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pucks : MonoBehaviour
{

    public Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set the mass and radius of the puck
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
    }
}
