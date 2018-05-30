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
        UpdateScore();

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

    void SpeedUp()
    {
        //Debug.Log("Speeding up...");
        FindObjectOfType<EnemyCarSpawn>().SpeedUp();
        // FindObjectOfType<CarMovement>().SpeedUp();
        foreach (TrackMovement gameobject in FindObjectsOfType<TrackMovement>())
        {
            gameobject.SpeedUp();
        }
    }

    public void EndGame()
    {
        gameObject.GetComponent<AudioSource>().Play();
        FindObjectOfType<UIManager>().GameOver();
    }
}

