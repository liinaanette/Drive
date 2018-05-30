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

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float direction = Input.GetAxis("Horizontal");
        if (direction > 0.0f)
        {
            if (rb.rotation > -3f) rb.rotation -= 0.5f;

        }
        else if (direction < 0.0f)
        {
            if (rb.rotation < 3f) rb.rotation += 0.5f;
        }
        else
        {

            rb.rotation = 0f;
        }

        position.x += direction * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, leftMax, rightMax);
        transform.position = position;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy Car"))
        {
            Destroy(gameObject);
        }
    }
}
