using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarMovement : MonoBehaviour {

    public float speed;
    float min = -4f;
    float max = -1f;

    void Start () {
        speed = Random.Range(min, max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Destroyer"))
        {
            Destroy(gameObject);
        }
        else
        {
            speed = -5f;
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    
}
