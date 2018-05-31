using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// For cars that are not taxis
public class OrdinaryCarMovement : CarMovement {

	// Just manage the movement on the track
	void Update () {
        transform.Translate(new Vector3(0,1,0) * speed * Time.deltaTime);
	}
     

}
