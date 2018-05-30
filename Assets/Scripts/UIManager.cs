using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;

    // Use this for initialization
    void Start () {
        Debug.Log("UI start");
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseText");
        HideGameOver();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reload()
    {
        //Application.LoadLevel(Application.loadedLevel);
        Debug.Log("Replay pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        ShowGameOver();
    }

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
}
