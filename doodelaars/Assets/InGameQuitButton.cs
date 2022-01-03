using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameQuitButton : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject PauseButton;
    bool GamePaused = false;
    bool setOnce = false;

    void Start()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (GamePaused)
        {
            Time.timeScale = 0;
            if (!setOnce)
            {
                PauseGame();
            }
        }
        else
        {
            Time.timeScale = 1;
            if (setOnce)
            {
                ResumeGame();
            }
        }
            
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void PauseGame() 
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.hideFlags = HideFlags.HideInHierarchy;
        PauseButton.SetActive(false);
        setOnce = true;
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
        setOnce = false;
    }

}
