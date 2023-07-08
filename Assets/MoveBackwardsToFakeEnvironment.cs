using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardsToFakeEnvironment : MonoBehaviour
{
    public float fixationSpeed = 1.0f;
    public float speedX = -4.0f;
    public float targetX = 0; // Set your target x position here
    public float targetY = 0; // Set your target y position here

    void Update()
    {
        float distX = Mathf.Abs(transform.position.x - targetX);
        float distY = Mathf.Abs(transform.position.y - targetY);

        float exponentialSpeedX = fixationSpeed * Mathf.Exp(distX);
        float exponentialSpeedY = fixationSpeed * Mathf.Exp(distY);

        transform.position += new Vector3(speedX * Time.deltaTime, 0, 0);

        if (transform.position.y < targetY)
        {
            transform.position += new Vector3(0, exponentialSpeedY * Time.deltaTime, 0);
        }
        else if (transform.position.y > targetY)
        {
            transform.position += new Vector3(0, -exponentialSpeedY * Time.deltaTime, 0);
        }

        if (transform.position.x < -3)
        {
            transform.position += new Vector3(exponentialSpeedY * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x > 3)
        {
            transform.position += new Vector3(-exponentialSpeedY * Time.deltaTime, 0, 0);
        }
    }
}
