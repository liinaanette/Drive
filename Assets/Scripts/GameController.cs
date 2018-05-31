using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


// Class for controlling many classes and scripts at once
public class GameController : MonoBehaviour {

    public float speedUpTime;
    float timer;
    float score;
    public Text scoreText;
    private int frame = 0;
    ReadAndWriteScores Scores;
    

	void Start () {
        Scores = FindObjectOfType<ReadAndWriteScores>();
        score = 0f;
        timer = speedUpTime;
    }
	
    // Update score and speed up
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
        FindObjectOfType<EnemyCarSpawn>().SpeedUp();
        foreach (TrackMovement gameobject in FindObjectsOfType<TrackMovement>())
        {
            gameobject.SpeedUp();
        }
    }

    // Plays the end game sound, tells UIManager to show game over sign and writes the scoreboard
    public void EndGame()
    {
        UpdateScore();
        gameObject.GetComponent<AudioSource>().Play();
        FindObjectOfType<UIManager>().GameOver();
        Scores.ReadAndWrite(score);
    }

    // When a coin is caught, it gives additional 30 points to score
    public void CoinScore()
    {
        score += 30;
    }
}

