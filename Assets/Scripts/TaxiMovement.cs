using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiMovement : CarMovement
{
    // Taxis drive erratically, they swerve around sometimes
    Vector3 straight = new Vector3(0, 1, 0);
    Vector3 right = new Vector3(0.3f, 1, 0);
    Vector3 left = new Vector3(-0.3f, 1, 0);
    bool swerveLeft = false;
    bool swerveRight = false;

    float swerveTime = 1.5f; // how long a swerve will last
    float timer = 0;

    void Update()
    {
        
        timer -= Time.deltaTime;

        // if the timer cycle has ended, we have to decide what the taxi will do for the next cycle
        // (either swerve to the right, to the left or drive straight)
        if (timer <= 0)
        {

            swerveLeft = false;
            swerveRight = false;
            timer = swerveTime; // timer is reset

            // 15% chance for the taxi to swerve in either direction
            float rand = Random.Range(0, 100);
            if (rand < 15)
            {
                swerveLeft = true;
            }
            else if (rand < 30)
            {
                swerveRight = true;
            }
        }
        
        // what the car is currently doing
        if (swerveLeft)
        {
            transform.Translate(left * speed * Time.deltaTime);
        } else if (swerveRight)
        {
            transform.Translate(right * speed * Time.deltaTime);
        } else
        {
            transform.Translate(straight * speed * Time.deltaTime);
        }

    }

}
