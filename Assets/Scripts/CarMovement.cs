using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Parent class for specific car movements, for example police car, taxi etc
public class CarMovement : MonoBehaviour {

    public float speed;
    float min = -3.5f;
    float max = -1.5f;

    // Get random speed so that cars move around with different speeds
    void Start () {
        speed = Random.Range(min, max);
	}
	
    // Collision for enemy car with other objects
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // objects leaving the scene are destroyed when they collide with a Destroyer gameobject
        if (collision.gameObject.tag.Equals("Destroyer"))
        {
            Destroy(gameObject);
        }
        
        // crash between cars slows down the speed
        else
        {
            if (!collision.gameObject.tag.Equals("Coin")) speed = -5f;

            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    
}
