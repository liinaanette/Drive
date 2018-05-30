using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float speed;
    public float leftMax = -2.9f;
    public float rightMax = 2.9f;
    Vector3 position;
    private Rigidbody2D rb;
    private HealthBar health;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        health = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float direction = Input.GetAxis("Horizontal");
        float rot = rb.rotation;

        // rotates car right or left depending on user input (direction)
        if (direction > 0.0f)
        {
            if (rot > -3f) rb.rotation -= 1f;

        }
        else if (direction < 0.0f)
        {
            if (rot < 3f) rb.rotation += 1f;
        }
        else
        {
            // smooth transition to straighten car
            if (rot > -0.5f && rot < 0.5f) rb.rotation = 0f;
            else if (rot > 0f && rot < 4f) rb.rotation -= 1f;
            else if (rot < 0f && rot > -4f) rb.rotation += 1f;
            else if (rot > 4f) rb.rotation -= 4f;
            else if (rot < -4f) rb.rotation += 4f;
          
            //rb.rotation = 0f;
        }

        position.x += direction * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, leftMax, rightMax);
        transform.position = position;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy Car"))
        {
            health.Hit(0.34f);
            // Destroy(gameObject);
            //FindObjectOfType<GameController>().EndGame();
        }
    }
}
