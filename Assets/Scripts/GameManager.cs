using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public AIController ai;
    public float aidelay = 1f;
    public static bool aiturn = false;
    public int ScoreP = 0;
    public int ScoreAI = 0;
    public Text ShortTimerTxt;
    public float timeRemaining = 11f;
    public TextMeshProUGUI[] gotxtscore;
    private bool isScoreDecreased = false;
    void Start()
    {
        ScoreP = 0;
        ScoreAI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (StrikerController.TurnOver)
        {
            StartCoroutine(AITurn());
        }
        else
        {
            // ai.enabled = false;
            aiturn = false;
        }
        if (!StrikerController.TurnOver && !StrikerController.striked)
        {
            ShortTimerUpdate();
        }
        else
        {
            timeRemaining = 10f;
        }
        if (Timer.TimeOver)
        {
            for (int i = 0; i < gotxtscore.Length; i++)
            {
                gotxtscore[i].text = ScoreP.ToString();
            }
        }
    }
    IEnumerator AITurn()
    {
        yield return new WaitForSeconds(aidelay);
        aiturn = true;
        // ai.enabled = true;
    }

    public void ShortTimerUpdate()
    {
        if (!Timer.TimeOver)
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float seconds = Mathf.FloorToInt(timeRemaining);
                ShortTimerTxt.text = seconds.ToString();
            }
            else if (timeRemaining <= 0 && !isScoreDecreased) // change condition to <= 0
            {
                Debug.Log("-1 point");
                ScoreP--;
                isScoreDecreased = true;
                timeRemaining = 0; // reset timer to 0
                ShortTimerTxt.text = "0"; // update text to show 0 seconds
            }
    }

}