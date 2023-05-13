using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerController : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector3 initialPosition;
    private Vector3 mousePosition;
    private bool isDraggingX = false;
    bool LockedX = false;
    bool isCharging = false;
    float boundary1;
    float boundary2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        boundary1 = -1.53f;
        boundary2 = 1.53f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraggingX)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newX = Mathf.Clamp(mousePosition.x, boundary1, boundary2);
            transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
        }

    }

    private void OnMouseDown()
    {
        if (!LockedX)
            if (!isDraggingX)
            {
                isDraggingX = true;
            }
            else
            {
                isDraggingX = false;
            }
    }

    public void onClickLock()
    {
        if (!LockedX)
        {
            LockedX = true;
            isCharging = true;
        }
        else
        {
            LockedX = false;
            isCharging = false;
        }
    }


}
