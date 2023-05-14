using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public AIController ai;
   public float aidelay = 1f;
   public static bool aiturn = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(StrikerController.TurnOver)
        {
            StartCoroutine(AITurn());
        }
        else
        {
            ai.enabled = false;
        }
    }
    IEnumerator AITurn()
    {
        yield return new WaitForSeconds(aidelay);
        aiturn = true;
        ai.enabled = true;
    }
    
}
