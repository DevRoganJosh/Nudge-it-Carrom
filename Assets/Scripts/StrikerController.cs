using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StrikerController : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector3 initialPosition;
    private Vector3 LockedPosition;
    private Vector3 mousePosition;
    private bool isDraggingX = false;
    bool LockedX = false;
    bool isCharging = false;
    float boundary1;
    float boundary2;
    float chargeClampY;
    RaycastHit2D hit;
    float CY;
    public float maxArrowScale = 2f;
    public LineRenderer Arrow;
    bool striked;
    public float forceMultiplier = 0.01f;

    public float stopThreshold = 0.1f;
    public float bounceForce = 1f;
    public static bool TurnOver = false;
    public static bool HasStopped = false;
    public static Vector3 AISide;
    Pucks tikkis;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        boundary1 = -1.53f;
        boundary2 = 1.53f;
        chargeClampY = -2.6f;
        AISide.x = initialPosition.x;
        AISide.y = initialPosition.y + 3.77f;
        tikkis = FindObjectOfType<Pucks>();
    }

    void Update()
    {

        if(!TurnOver && !CheckPucks.allDeactivated)
        {
            MyTurn();
        }
        else
        {
            transform.position = new Vector2(AISide.x,AISide.y);
        }

    }

    private void OnMouseDown()
    {   
        if(rb.velocity.magnitude < stopThreshold && tikkis.rb.velocity.magnitude < stopThreshold && !TurnOver && !CheckPucks.allDeactivated)
        if (!LockedX)
        {
            if (!isDraggingX)
            {
                isDraggingX = true;
            }
            else
            {
                isDraggingX = false;
                LockedPosition = transform.position;
            }
        }
        else
        {
            isCharging = true;
        }
    }
    private void OnMouseUp()
    {  
        if (isCharging)
        {
            isCharging = false;
            striked = true;

            Strike();
        }
    }

    public void onClickLock()
    {   
       if(rb.velocity.magnitude < stopThreshold && tikkis.rb.velocity.magnitude < stopThreshold)
        if (!LockedX)
        {
            LockedX = true;

        }
        else
        {
            LockedX = false;
            isCharging = false;
        }
    }
    public void Strike()
    {
        float distance = Vector3.Distance(transform.position, LockedPosition);
        float strength = distance * forceMultiplier / Mathf.Max(0.1f, CY - chargeClampY);
        Vector2 direction = Arrow.GetPosition(1) - Arrow.GetPosition(0);
        rb.AddForce(direction.normalized * strength, ForceMode2D.Impulse);
        Arrow.enabled = false;
    }

    public void MyTurn()
    {
        TurnOver = false;
        if (isDraggingX && !striked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newX = Mathf.Clamp(mousePosition.x, boundary1, boundary2);
            transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
        }
        if (isCharging && !striked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float CX = Mathf.Clamp(mousePosition.x, LockedPosition.x - 0.42f, LockedPosition.x + 0.42f);
            CY = Mathf.Clamp(mousePosition.y, chargeClampY, -2.17f);
            transform.position = new Vector3(CX, CY, initialPosition.z);

            Arrow.enabled = true;
            Arrow.SetPosition(0, transform.position);
            Arrow.SetPosition(1, -mousePosition);

        }
        else if (striked && rb.velocity.magnitude < stopThreshold && tikkis.rb.velocity.magnitude < stopThreshold)
        {
            // Striker has stopped moving
            rb.velocity = Vector2.zero;
            transform.position = initialPosition;
            Arrow.enabled = false;
            striked = false;
            LockedX = false;
            TurnOver = true;
            HasStopped = true;
            GameManager.aiturn = true;

        }
    }

}




