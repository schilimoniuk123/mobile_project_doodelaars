using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameQuitButton : MonoBehaviour
{

    public GameObject resumeButton;
    void Start()
    {
        
        resumeButton.SetActive(false);
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void PauseGame() 
    {
        ///TODO poepke genaaid - deze rommel fixe
        resumeButton.SetActive(true);
        Debug.Log("eneenjenjejnee");
        Time.timeScale = 0;
        Debug.Log("eneenjenjejnee");    
    }

    public void ResumeGame()
    {
        resumeButton.SetActive(false);
        Time.timeScale = 1;
    }

}
