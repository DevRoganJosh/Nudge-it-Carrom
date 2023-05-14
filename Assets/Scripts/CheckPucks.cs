using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPucks : MonoBehaviour
{
    public static bool allDeactivated = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        foreach (Pucks go in GameObject.FindObjectsOfType<Pucks>())
        {
            if (!go.gameObject.activeSelf)
            {
                allDeactivated = true;
                break;
            }
        }

        if (allDeactivated)
        {
            Debug.Log("All gameobjects are deactivated.");
        }
        else
        {
            Debug.Log("Not all gameobjects are deactivated.");
        }

    }
}
