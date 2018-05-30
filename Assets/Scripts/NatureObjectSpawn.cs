using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureObjectSpawn : MonoBehaviour {

    GameObject[] nature;
    float delay = 5f;
    float timer;

    // Use this for initialization
    void Start () {
        nature = Resources.LoadAll<GameObject>("Prefabs/Nature");
        timer = delay;
    }
	
	// Update is called once per frame
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
        int random = Random.Range(4, 14);
        if (random > 9)
        {
            random = 5 - random;
        }

        Vector3 position = new Vector3(random, transform.position.y, transform.position.z);
        GameObject randomObject = nature[Random.Range(0, nature.Length)];
        GameObject obj = Instantiate(randomObject, position, transform.rotation);
    }
}
