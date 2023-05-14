using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pockets : MonoBehaviour
{
    GameManager gm;
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
    }
}
