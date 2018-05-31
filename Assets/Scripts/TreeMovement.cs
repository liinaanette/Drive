using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for managing the movement of nature objects
public class TreeMovement : MonoBehaviour {

    public float speed = -5f;
	void Start () {
		
	}

    // Make the object move
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // objects leaving the scene are destroyed
        if (collision.gameObject.tag.Equals("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

}
