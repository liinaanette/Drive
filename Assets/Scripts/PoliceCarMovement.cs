using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarMovement : CarMovement {

    public float speed = -5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    override
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Destroyer"))
        {
            Destroy(gameObject);
        } else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    override
    public void SpeedUp()
    {
        speed += 0.1f;
    }
}
