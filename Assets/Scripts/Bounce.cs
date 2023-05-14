using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bounce : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D otherRB = collision.gameObject.GetComponent<Rigidbody2D>();
        if (otherRB != null)
        {
            Vector2 bounceDirection = (otherRB.transform.position - transform.position).normalized;
            otherRB.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}
