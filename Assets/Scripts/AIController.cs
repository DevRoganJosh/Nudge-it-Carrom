using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float maxForce = 40f;
    public float minForce = 20f;
    private Rigidbody2D rb;
    private StrikerController striker;
    public static bool AIStriked;
    public GameObject TO;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        striker = FindObjectOfType<StrikerController>();
    }

    void Update()
    {
        if (GameManager.aiturn && StrikerController.HasStopped && Pockets.counter < 17 && !AIStriked && !Timer.TimeOver && !Buttons.isPaused)
        {
            Pucks[] pucks = FindObjectsOfType<Pucks>();
            int index = Random.Range(0, pucks.Length);
            Pucks puck = pucks[index];

            // Calculate a random force to hit the puck with
            float force = Random.Range(minForce, maxForce);

            // Calculate the direction to hit the puck in
            Vector2 direction = (puck.transform.position - transform.position).normalized;

            // Strike the striker with the calculated force and direction
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            AIStriked = true;

        }

        if (AIStriked && rb.velocity.magnitude < 0.001f)
        {
            StrikerController.TurnOver = false;
            TO.SetActive(true);
        }
        if (GameManager.aiturn)
        {
            TO.SetActive(false);
        }
    }
}
