using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawn : MonoBehaviour {

    public GameObject truck;
    public GameObject police;
    public GameObject viper;
    GameObject[] cars;

    // possible positions on road
    float[] xPos = new float[] {-2f, 0f, 2f};
    public float delay = 1f;
    float timer;

	// Use this for initialization
	void Start () {
        timer = delay;
        cars = new GameObject[] { truck, truck, police, viper, viper, viper };
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnCar();
            timer = delay;
        }
    }

    void SpawnCar()
    {
        // lane is chosen randomly
        int random = Random.Range(0, 3);
        float x = xPos[random];
        Vector3 position = new Vector3(x, transform.position.y, transform.position.z);
        GameObject randomCar = cars[Random.Range(0, cars.Length)];
        Instantiate(randomCar, position, transform.rotation);
    }

    public void SpeedUp()
    {
        delay -= 0.05f;
    }
}
