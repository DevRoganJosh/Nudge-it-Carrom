using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    GameManager gm;
    public static int counter=0;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Black" || other.gameObject.tag == "White")
        {   
            counter++;
            if (GameManager.aiturn)
            {
                gm.ScoreAI++;
                Debug.Log("Ai Score : " + gm.ScoreAI);
                other.gameObject.SetActive(false);
            }
            else if (!GameManager.aiturn)
            {
                gm.ScoreP++;
                Debug.Log("Player Score : " + gm.ScoreP);
                other.gameObject.SetActive(false);
            }
        }
        else if(other.gameObject.tag == "Queen")
        {   
            counter++;
            if (GameManager.aiturn)
            {
                gm.ScoreAI+=2;
                Debug.Log("Ai Score : " + gm.ScoreAI);
                other.gameObject.SetActive(false);
            }
            else if (!GameManager.aiturn)
            {
                gm.ScoreP+=2;
                Debug.Log("Player Score : " + gm.ScoreP);
                other.gameObject.SetActive(false);
            }
        }
        else if(other.gameObject.tag == "Striker")
        {
            if(GameManager.aiturn)
            {
                GameManager.aiturn = false;
                if(gm.ScoreAI>0)
                gm.ScoreAI--;
            }
            if(!GameManager.aiturn)
            {
                GameManager.aiturn = true;
                if(gm.ScoreP>0)
                gm.ScoreP--;
            }
        }

    }
}
