using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns trees and cacti
public class NatureObjectSpawn : MonoBehaviour {

    GameObject[] nature;
    float delay = 5f;
    float timer;

    // Find all nature prefabs
    void Start () {
        nature = Resources.LoadAll<GameObject>("Prefabs/Nature");
        timer = delay;
    }
	
	// Spawn one after timer hits zero
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();
            timer = delay;
        }
	}

    void Spawn()
    {
        // Finds a random place outside the track on the grass
        int random = Random.Range(4, 12);
        if (random > 9)
        {
            random = 4 - random;
        }

        Vector3 position = new Vector3(random, transform.position.y, transform.position.z);

        // Random nature object
        GameObject randomObject = nature[Random.Range(0, nature.Length)];
        Instantiate(randomObject, position, transform.rotation);
    }
}
