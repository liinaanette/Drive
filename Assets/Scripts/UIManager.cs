using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class for showing GUI
public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    GameObject[] scoreboard;

    // Find necessary files and hide them
    void Start () {
        // Debug.Log("UI start");
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseText");
        scoreboard = GameObject.FindGameObjectsWithTag("Scoreboard");
        HideGameOver();
        HideScoreboard();
    }
	
    // Level is loaded again
    public void Reload()
    {
        Debug.Log("Replay pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    // Application is quit
    public void Exit()
    {
        Application.Quit();
    }

    // Level is loaded and the player can play
    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    // Show the main menu
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    // Show the game over text and scoreboard
    public void GameOver()
    {
        Time.timeScale = 0;
        ShowScoreboard();
        ShowGameOver();
    }

    // Methods for hiding and showing objects

    public void HideGameOver()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void ShowGameOver()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void HideScoreboard()
    {
        foreach (GameObject g in scoreboard)
        {
            g.SetActive(false);
        }
    }

    public void ShowScoreboard()
    {
        foreach (GameObject g in scoreboard)
        {
            g.SetActive(true);
        }
    }
}
