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
    float ChargeClampX1;
    float ChargeClampX2;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        boundary1 = -1.53f;
        boundary2 = 1.53f;
        chargeClampY = -2.6f;
        ChargeClampX1 = -0.42f;
        ChargeClampX2 = 0.42f;
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
            float CY = Mathf.Clamp(mousePosition.y, chargeClampY, -2.17f);
            transform.position = new Vector3(CX, CY, initialPosition.z);
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
