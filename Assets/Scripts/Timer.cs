using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 120f;
    public static bool TimeOver = false;
    public TextMeshProUGUI timerText;
    public GameObject GamePanel;
    public GameObject GameOverPanel;

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
        GameOver();
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        if(TimeOver)
        {
            GamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }
    }
}
