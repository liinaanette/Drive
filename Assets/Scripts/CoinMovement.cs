using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for moving the coin around the track
public class CoinMovement : MonoBehaviour {

    float speed = -3f;
	
	
	// The coin is just moving on the y axis
	void Update () {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    // On collision with objects
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // when the collided object is player, a sound is played at this position, coin is destroyed and game score is updated
        if (collision.gameObject.tag.Equals("Player"))
        {
            AudioClip clip = gameObject.GetComponent<AudioSource>().clip;
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            FindObjectOfType<GameController>().CoinScore();
            Destroy(gameObject);

        } else
        {
            Destroy(gameObject);
        }
    }
}
