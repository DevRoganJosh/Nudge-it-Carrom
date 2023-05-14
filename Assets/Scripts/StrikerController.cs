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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        boundary1 = -1.53f;
        boundary2 = 1.53f;
        chargeClampY = -2.6f;
    }

    void Update()
    {
        if (isDraggingX)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newX = Mathf.Clamp(mousePosition.x, boundary1, boundary2);
            transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
        }
        if (isCharging)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float CX = Mathf.Clamp(mousePosition.x, LockedPosition.x - 0.42f, LockedPosition.x + 0.42f);
             CY = Mathf.Clamp(mousePosition.y, chargeClampY, -2.17f);
            transform.position = new Vector3(CX, CY, initialPosition.z);

            if (!striked)
            {
                Arrow.SetPosition(0, transform.position);
                Arrow.SetPosition(1, -mousePosition);
            }


        }

    }

    private void OnMouseDown()
    {
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

            float distance = Vector3.Distance(transform.position, LockedPosition);
            float strength = distance * forceMultiplier / Mathf.Max(0.1f, CY - chargeClampY);
            Vector2 direction = Arrow.GetPosition(1) - Arrow.GetPosition(0);
            rb.AddForce(direction.normalized * strength, ForceMode2D.Impulse);
            Arrow.enabled = false;
        }
    }

    public void onClickLock()
    {
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


}

