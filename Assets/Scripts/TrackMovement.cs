using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class makes the track element move under the car
 */
public class TrackMovement : MonoBehaviour {

    // The speed of the movement
    public float speed;
    // The direction of the movement
    Vector2 offset;

	// Make the track move
	void Update () {
        offset = new Vector2(0,Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}

    public void SpeedUp()
    {
        speed += 0.1f;
    }

}

