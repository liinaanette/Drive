using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for managing how often coins are spawned on the track
public class CoinSpawn : MonoBehaviour {

    GameObject coin;
    float delay = 15f;
    float timer;

    // Find the coin prefab
    void Start()
    {
        coin = Resources.Load<GameObject>("Prefabs/Other/coinPrefab");
        timer = delay;
    }

    // Deltatime is subtracted from timer until it hits zero and then a new coin is spawned
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();
            timer = delay;
        }
    }

    // Find a random x value on the track and instantiate there a new coin
    void Spawn()
    {
        float random = Random.Range(-2.9f, 2.9f);

        Vector3 position = new Vector3(random, transform.position.y, transform.position.z);
        Instantiate(coin, position, transform.rotation);
    }

    
}
