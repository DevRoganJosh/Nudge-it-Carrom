using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public AIController ai;
   public float aidelay = 1f;
   public static bool aiturn = false;
   public int ScoreP = 0;
   public int ScoreAI = 0;
   public bool IsGameOver = false;
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
            aiturn = false;
        }
        if(IsGameOver)
        {   
            ai.enabled = false;
            if(ScoreAI>ScoreP)
            {
                Debug.Log("You Lost");
            }
            else
            {
                Debug.Log("You Won");
            }
        }
    }
    IEnumerator AITurn()
    {
        yield return new WaitForSeconds(aidelay);
        aiturn = true;
        ai.enabled = true;
    }
    
}
