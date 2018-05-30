using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour {

    float speed = -5f;
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    public void SpeedUp()
    {
        speed -= 3f;
    }
}
