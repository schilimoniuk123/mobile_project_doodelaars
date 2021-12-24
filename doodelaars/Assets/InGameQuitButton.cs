using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameQuitButton : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject PauseButton;
    bool GamePaused;

    void Start()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void PauseGame() 
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(false);
    }

}
