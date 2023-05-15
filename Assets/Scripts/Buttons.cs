using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GamePanel;
    public static bool isPaused;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Intro");
        isPaused = false;
    }
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            GamePanel.SetActive(false);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            GamePanel.SetActive(true);
            isPaused = false;
        }

    }
    public void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GamePanel.SetActive(true);
        isPaused = false;
    }
    
}
