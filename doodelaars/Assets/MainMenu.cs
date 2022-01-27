using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject retryButton;
    void Start()
    {
        
        retryButton.hideFlags = HideFlags.HideInHierarchy;
        retryButton.SetActive(false);

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
        
    }

}
