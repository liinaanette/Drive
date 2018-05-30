using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void OnCollisionEnter2D(Collision2D collision);

    public abstract void SpeedUp();
}
