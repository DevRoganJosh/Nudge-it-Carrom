using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pockets : MonoBehaviour
{
    GameManager gm;
    public static int counter = 0;
    public TextMeshProUGUI PlayerScoreText;
    public TextMeshProUGUI AIScoreText;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        AIScoreText.text = gm.ScoreAI.ToString();
        PlayerScoreText.text = gm.ScoreP.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Black" || other.gameObject.tag == "White")
        {
            counter++;
            if (GameManager.aiturn)
            {
                gm.ScoreAI++;
                AIScoreText.text = gm.ScoreAI.ToString();
                other.gameObject.SetActive(false);
            }
            else if (!StrikerController.TurnOver)
            {
                gm.ScoreP++;
                PlayerScoreText.text = gm.ScoreP.ToString();
                other.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "Queen")
        {
            counter++;
            if (GameManager.aiturn)
            {
                gm.ScoreAI += 2;
                AIScoreText.text = gm.ScoreAI.ToString();
                other.gameObject.SetActive(false);
            }
            else if (!GameManager.aiturn)
            {
                gm.ScoreP += 2;
                PlayerScoreText.text = gm.ScoreP.ToString();
                other.gameObject.SetActive(false);
            }
        }

    }
}
