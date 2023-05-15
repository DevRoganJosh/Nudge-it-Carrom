using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 120f;
    public static bool TimeOver = false;
    public TextMeshProUGUI timerText;
    public GameObject GamePanel;
    public GameObject GameOverPanelW;
    public GameObject GameOverPanelD;
    public GameObject GameOverPanelL;
    public GameManager gm;

    private void Start() 
    {
        timeRemaining = 120f;
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "00:00";
            TimeOver = true;
        }
        GameOverW();
        if(Pockets.counter==17)
        {
            TimeOver = true;
            timeRemaining = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOverW()
    {
        if (TimeOver)
        {
            if (gm.ScoreP > gm.ScoreAI)
            {
                GamePanel.SetActive(false);
                GameOverPanelW.SetActive(true);
            }
            else if (gm.ScoreP == gm.ScoreAI)
            {
                GamePanel.SetActive(false);
                GameOverPanelD.SetActive(true);
            }
            else
            {
                GamePanel.SetActive(false);
                GameOverPanelL.SetActive(true);
            }

        }
    }
}
