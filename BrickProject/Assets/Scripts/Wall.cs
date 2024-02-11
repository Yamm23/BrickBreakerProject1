using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float maxAngle = 75f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            // Get the current velocity of the ball
            Vector2 currentVelocity = ball.myrigidbody.velocity;

            // Calculate a random angle between -maxAngle and maxAngle
            float randomAngle = Random.Range(-maxAngle, maxAngle);

            // Rotate the current velocity by the random angle
            Vector2 newVelocity = Quaternion.Euler(0, 0, randomAngle) * currentVelocity;

            // Set the new velocity to the ball
            ball.myrigidbody.velocity = newVelocity;
        }
    }
}

