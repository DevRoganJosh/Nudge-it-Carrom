using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnClickButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
