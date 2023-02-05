using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    private bool areCreditsOpen = false;
    [SerializeField] private GameObject creditsWindow;

    public void OnPlayBtn()
    {
        Debug.Log("Loading the scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnCreditsBtn()
    {
        if (areCreditsOpen)
        {
            areCreditsOpen = false;
            creditsWindow.SetActive(false);
        }
        else
        {
            areCreditsOpen = true;
            creditsWindow.SetActive(true);
        }
    }

    public void OnQuitBtn()
    {
        Application.Quit();
        Debug.Log("Exiting the game...");
    }
    
}
