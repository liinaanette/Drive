using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float speedUpTime;
    float timer;
    float score;
    public Text scoreText;
    private int frame = 0;
    ReadAndWriteScores Scores;
    

	// Use this for initialization
	void Start () {
        Scores = FindObjectOfType<ReadAndWriteScores>();
        score = 0f;
        timer = speedUpTime;
        // Scores.ReadAndWrite();
    }
	
	// Update is called once per frame
	void Update () {
        score += 1 * Time.deltaTime;

        // updates score every 5th frame
        if (frame % 5 == 0) UpdateScore();
        frame++;
        

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpeedUp();
            timer = speedUpTime;
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString("0.00");
    }

    // speeds up track movement speed, enemy car spawn rate
    void SpeedUp()
    {
        //Debug.Log("Speeding up...");
        FindObjectOfType<EnemyCarSpawn>().SpeedUp();
        foreach (TrackMovement gameobject in FindObjectsOfType<TrackMovement>())
        {
            gameobject.SpeedUp();
        }
        foreach (TreeMovement gameobject in FindObjectsOfType<TreeMovement>())
        {
            gameobject.SpeedUp();
        }
    }

    public void EndGame()
    {
        UpdateScore();
        gameObject.GetComponent<AudioSource>().Play();
        FindObjectOfType<UIManager>().GameOver();
        Scores.ReadAndWrite(score);
    }

    
}

