using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float speedUpTime;
    float timer;
    float score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0f;
        timer = speedUpTime;
    }
	
	// Update is called once per frame
	void Update () {
        score += 1 * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpeedUp();
            timer = speedUpTime;
        }
    }

    void UpdateScore(float newScore)
    {
        scoreText.text = "Score: " + score;
    }

    void SpeedUp()
    {
        Debug.Log("Speeding up...");
        FindObjectOfType<EnemyCarSpawn>().SpeedUp();
        FindObjectOfType<EnemyCarMovement>().SpeedUp();
        FindObjectOfType<TrackMovement>().SpeedUp();
    }
}

