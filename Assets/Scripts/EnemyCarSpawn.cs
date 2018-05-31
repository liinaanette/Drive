using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for managing how often and where enemy cars are spawned
public class EnemyCarSpawn : MonoBehaviour {

    GameObject[] cars;

    // possible positions on road between the road lines
    float[] xPos = new float[] {-2f, 0f, 2f};
    public float delay = 1f;
    float timer;

	// Find the car prefabs
	void Start () {
        timer = delay;
        cars = Resources.LoadAll<GameObject>("Prefabs/Cars");
	}
	
	// When timer hits zero, a new car is spawned
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

        // Car is chosen randomly
        GameObject randomCar = cars[Random.Range(0, cars.Length)];
        Instantiate(randomCar, position, transform.rotation);
    }

    public void SpeedUp()
    {
        delay -= 0.05f;
    }
}
